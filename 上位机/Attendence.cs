using CqustRfidSystem.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CqustRfidSystem
{
    public partial class Attendence : Form
    {
        private StringBuilder buffer = new StringBuilder();

        private bool is_first_re_ok = true;
        Dictionary<string,SerialPort> sp =new Dictionary<string,SerialPort>();

        string read_sno_flag = "0";
        public Attendence()
        {
            InitializeComponent();
        }

        private void Attendence_Load(object sender, EventArgs e)
        {

            string[] ports = SerialPort.GetPortNames();//获取计算机可用串口
            if (ports.Length > 0)//有可用串口
            {
                comboBox_port.Items.AddRange(ports);
                comboBox_port.SelectedIndex = 0;
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            is_first_re_ok=true;
            textBox_place.Text = "I118";
            string pattern = @"^[A-Z]\d{3}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(textBox_place.Text) && comboBox_port.Text != "")
            {
               
    
               
  
                SerialPort ports = new SerialPort();
                ports.PortName = comboBox_port.Text;
                ports.BaudRate = 4800;
                Serialport.open_usrt(ports);
                ports.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                sp[comboBox_port.Text] = ports;

                //设置地点：
                string set_place_data = "s" + textBox_place.Text + "0000000000#";
               // string set_place_data = "sI1180000000000#";
           
                Serialport.send_string_to_byte_data(ports,set_place_data);

            }
            else {
                MessageBox.Show("请正确配置","提示");
            }
        }

 

        private void btn_open_Click_1(object sender, EventArgs e)
        {
            //开启打卡模式
            Serialport.send_string_to_byte_data(sp[comboBox_port.Text], "d00000000000000#");
            log_text.SelectionColor = Color.Green;
            log_text.AppendText($"{DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ")}Rfid_reader: 开启打卡模式成功" + Environment.NewLine);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
    
            SerialPort uart = (SerialPort)sender;
            int bytesToRead = uart.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            uart.Read(buffer, 0, bytesToRead);

            foreach (byte b in buffer)
            {
                this.buffer.Append((char)b);
            }

            string data = this.buffer.ToString();

            //一个很傻逼的bug 排查了很久找不到原因 为什么单片机重启后第一次发送的数据只有15个字节  于是只能在上位机这里进行处理.
            if (data.Length == 15)
            {
                this.buffer.Clear();
                return;
            }


            if (data.Length >= 16)
            {
                this.buffer.Clear();

                if (data.StartsWith("ok") && data[15] == '#')
                {
                  
                    if (is_first_re_ok)
                    {

                        log_text.Invoke((MethodInvoker)delegate
                          {
                              log_text.SelectionColor = Color.Green;
                              log_text.AppendText($"{DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ")} Rfid_reader:  串口 {uart.PortName}  设置地址 {textBox_place.Text} 成功" + Environment.NewLine);

                          });
                        is_first_re_ok = false;
                    }

                }

                if (data.StartsWith("d") && data[15] == '#')
                {
                  
                    string sno = data.Substring(1, 10);               
                    if (sno.Equals(read_sno_flag))
                    {
                        return;
                    }
                    read_sno_flag = sno;
                    log_text.Invoke((MethodInvoker)delegate
                    {
                        label_student_id.Text = sno;
                        label_place.Text = data.Substring(11, 4);
                        string  add_attendance_url = Config.BASE_URL + "add_attendance";
                        string time_str = DateTime.Now.ToString("HH:mm:ss");
                        var postData = new Dictionary<string, object>{
                        {"sno", sno},{"time_str", time_str},{"place",label_place.Text} };
                        var response = Httpx.Post(add_attendance_url, postData);
                        if (response.TryGetValue("flag", out object flagValue))
                        {
                            string flag = flagValue.ToString();
                            string send_print_data = "";
                            log_text.SelectionColor = Color.Blue;
                            switch (flag)
                            {
                                case Config.FLAG_NOT_IN_ATTENDANCE_TIME:
                                 
                                    log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "Server:" + $" 不在考勤时间" + Environment.NewLine);
                                    //不在考勤时间
                                    send_print_data = "dp2000000000000#";
                                    Serialport.send_string_to_byte_data(uart, send_print_data);
                                    break;
                                case Config.FLAG_THIS_TIME_STUDENT_NOT_COURSE:
                                    log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "Server:" + $"学号 {sno} 此时间段无课" + Environment.NewLine);
                                    //该时间没有课
                                    send_print_data = "dp3000000000000#";
                                    Serialport.send_string_to_byte_data(uart, send_print_data);
                                    break;
                                case Config.FLAG_ADD_ATTENDANCE_NOT_SUCCESS:
                                    log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "Server:" + $"学号 {sno} 考勤失败" + Environment.NewLine);
                                    //添加记录失败
                                    send_print_data = "dp1000000000000#";
                                    Serialport.send_string_to_byte_data(uart, send_print_data);
                                    break;
                                case Config.FLAG_ERROR:
                                    send_print_data = "dp1000000000000#";
                                    Serialport.send_string_to_byte_data(uart, send_print_data);
                                    break;
                                case Config.FLAG_THIS_TIME_IS_ATTENDANCE:
                                    log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "Server:" + $"学号 {sno} 本节课已打卡" + Environment.NewLine);
                                    //本时间段已经打过卡了
                                    send_print_data = "dp4000000000000#";
                                    Serialport.send_string_to_byte_data(uart, send_print_data);
                                    break;
                                case Config.FLAG_OK:
                                    if (response.TryGetValue("data", out object dataValue2) && dataValue2 is JObject dataObject2)
                                    {
                                        if (dataObject2.TryGetValue("stu_name", out var userNameValue2) && userNameValue2 is JValue userNameJValue2)
                                        {
                                            string stu_name = userNameJValue2.Value.ToString();

                                            if (dataObject2.TryGetValue("state", out var vstate) && vstate is JValue vjstate)                                          
                                            { 
                                                int state_flag =int.Parse( vjstate.Value.ToString());
                                                string state="";
                                                if (state_flag == 0) { state = "正常"; send_print_data = "dp0000000000000#"; }
                                                else if (state_flag == 1) { state = "迟到"; send_print_data = "dp0100000000000#"; }
                                                else if(state_flag == 2) { state = "缺勤"; send_print_data = "dp0200000000000#"; }
                                                Serialport.send_string_to_byte_data(uart, send_print_data);
                                                log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "Server:" + $" 学号 {sno} 学生 {stu_name} 打卡成功 状态 {state}" + Environment.NewLine);
                                            }
                                                
                                        }

                            
                                        
                                    }
                                    break;
                            }
                        }
                        /*log_text.SelectionColor = Color.Green;
                        log_text.AppendText($"{DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ")}Rfid_reader: 设置地址 {textBox_place.Text} 成功" + Environment.NewLine);*/

                    });

                }
       
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            if (comboBox_port.Text != null) {
                Serialport.close_usrt(sp[comboBox_port.Text]);
            }
        }

        private void log_text_TextChanged(object sender, EventArgs e)
        {
            log_text.SelectionStart = log_text.Text.Length;
            log_text.ScrollToCaret();
        }
    }
}
