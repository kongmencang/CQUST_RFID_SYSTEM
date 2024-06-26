using CqustRfidSystem.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace CqustRfidSystem
{
    public partial class SendCard : Form
    {
        private StringBuilder buffer = new StringBuilder();
        string get_info_url = Config.BASE_URL + "get_info";
        string add_card_url = Config.BASE_URL + "add_card";
        string port_name;
        int port_baudrate=4800;
        private bool isProcessing = false;

        //读到的卡号
        string read_card_id_flag="0";
        //成功表示
        string read_card_ok_flag="0";



        private bool requirt_add_card(string card_id, string sno)
        {
            // 准备发送的数据
            var postData = new Dictionary<string, object>
    {
        {"sno", sno},
        {"card_id", card_id}
    };

            // 发送 HTTP POST 请求
            var response = Httpx.Post(add_card_url, postData);
            if (response != null)
            {
                // 尝试获取响应中的 "flag" 字段
                if (response.TryGetValue("flag", out object flagValue))
                {
                    string flag = flagValue.ToString();
                    switch (flag)
                    {
                        case Config.FLAG_ERROR:
                            MessageBox.Show("请求错误", "警告");
                            return false;
                            break;
                        case Config.FLAG_NOT_STUDENT:
                            MessageBox.Show("学生不存在", "警告");
                            return false;
                            break; // 这种情况应该已经排除了
                        case Config.FLAG_USER_HAVE_CARD:
                            MessageBox.Show("该用户已经有卡了", "警告");
                            return false;
                            break; // 这种情况也已经排除了  
                        case Config.FLAG_CARD_IS_USING:
                            // 如果卡片正在使用，获取绑定的学生姓名
                            if (response.TryGetValue("data", out object dataValue) && dataValue is JObject dataObject)
                            {
                                if (dataObject.TryGetValue("name", out var userNameValue) && userNameValue is JValue userNameJValue)
                                {
                                    string stu_name = userNameJValue.Value.ToString();
                                    MessageBox.Show($"该卡片已绑定学生 {stu_name}", "警告");
                                    return false;
                                }
                            }
                            break;
                        case Config.FLAG_ADD_CARD_NOT_SUCCESS:
                            MessageBox.Show("卡片注册失败", "警告");
                            return false;
                            break; // 防止恶意请求  
                        case Config.FLAG_OK:
                            {

                                // 如果卡片绑定成功，获取学生姓名并更新日志和界面
                                if (response.TryGetValue("data", out object dataValue2) && dataValue2 is JObject dataObject2)
                                {
                                    if (dataObject2.TryGetValue("name", out var userNameValue2) && userNameValue2 is JValue userNameJValue2)
                                    {
                                        string stu_name = userNameJValue2.Value.ToString();
                                        log_text.SelectionColor = Color.Blue;                                  
                                        log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "Server:" + $" 学生 {stu_name} 绑定卡片 {card_id} 成功" + Environment.NewLine);
                                       
                                        string send_data = "w" + comboBox_student_id.Text.Trim() + "0000#";
                                        Serialport.send_string_to_byte_data(port, send_data);
                                        ClearDependentComboboxes(comboBox_student_id);
                                        UpdateDependentComboboxes("not_have_card_stu_info");
                                    }
                                }

                          

                                return true;

                            }
          
                        
                            break;
                    }
                }
            }
            return false;
        }

        public SendCard()
        {
            InitializeComponent();
        }

        private void SendCard_Load(object sender, EventArgs e)
        {
            if (share_info.user_power == "0")
            {
              
                RequestData("school_info", comboBox_school_name, share_info.user_manage_school, "school_name", "school_id");
            }
       
           
        }

        private void RequestData(string infoName, ComboBox comboBox, Dictionary<string, string> storageDict, string displayName, string idName)
        {
            var postData = new Dictionary<string, object>
            {
                { "info_name", infoName }
            };
            if (infoName != "school_info")
            {
                postData["info_argument"] = new Dictionary<string, string>
                {
                    { GetArgumentKey(infoName), GetArgumentValue(infoName) }
                };
            }
    

            var response = Httpx.Post(get_info_url, postData);
           
            if (response != null && response.TryGetValue("flag", out object flagValue))
            {
           
                string flag = flagValue.ToString();
                if (flag == Config.FLAG_ERROR)
                {
                    MessageBox.Show("请求错误", "警告");
                }
                else if (flag == Config.FLAG_OK && response.TryGetValue("data", out object dataValue) && dataValue is JArray dataArray)
                {
                    comboBox.Items.Clear();
                    storageDict.Clear();
                    foreach (var item in dataArray)
                    {
                        var info = item.ToObject<Dictionary<string, string>>();
                        comboBox.Items.Add(info[displayName]);
                        storageDict[info[displayName]] = info[idName];
                    }
                    if (comboBox.Items.Count != 0)
                    {
                        comboBox.SelectedIndex = 0;
                    }
                }
            }
        }

        private string GetArgumentKey(string infoName)
        {
            switch (infoName)
            {
                case "department_info": return "school_id";
                case "subject_info": return "department_id";
                case "class_info": return "subject_id";
                case "not_have_card_stu_info": return "class_id";
                default: return "";
            }
        }

        private string GetArgumentValue(string infoName)
        {
            switch (infoName)
            {
                case "department_info": return share_info.user_manage_school[comboBox_school_name.Text];
                case "subject_info": return share_info.user_manage_department[comboBox_department_name.Text];
                case "class_info": return share_info.user_manage_subject[comboBox_subject_name.Text];
                case "not_have_card_stu_info": return share_info.user_manage_class[comboBox_class_name.Text];
                default: return "";
            }
        }

        private void comboBox_school_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                ClearDependentComboboxes(comboBox_school_name);
                UpdateDependentComboboxes("department_info");
            }
        }

        private void comboBox_department_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                ClearDependentComboboxes(comboBox_department_name);
                UpdateDependentComboboxes("subject_info");
            }
        }

        private void comboBox_subject_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                ClearDependentComboboxes(comboBox_subject_name);
                UpdateDependentComboboxes("class_info");
            }
        }

        private void comboBox_class_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                ClearDependentComboboxes(comboBox_class_name);
                UpdateDependentComboboxes("not_have_card_stu_info");
            }
        }

        private void comboBox_student_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            lable_student_name.Text = "姓名：" + share_info.user_manage_student[comboBox_student_id.Text];
        }

        private void ClearDependentComboboxes(ComboBox changedComboBox)
        {
            if (changedComboBox == comboBox_school_name)
            {
                comboBox_department_name.Items.Clear();
                comboBox_department_name.Text = "";
                comboBox_subject_name.Items.Clear();
                comboBox_subject_name.Text = "";
                comboBox_class_name.Items.Clear();
                comboBox_class_name.Text = "";
                comboBox_student_id.Items.Clear();
                comboBox_student_id.Text = "";
                lable_student_name.Text = "姓名";
            }
            else if (changedComboBox == comboBox_department_name)
            {
                comboBox_subject_name.Items.Clear();
                comboBox_subject_name.Text = "";
                comboBox_class_name.Items.Clear();
                comboBox_class_name.Text = "";
                comboBox_student_id.Items.Clear();
                comboBox_student_id.Text = "";
                lable_student_name.Text = "姓名";
            }
            else if (changedComboBox == comboBox_subject_name)
            {
                comboBox_class_name.Items.Clear();
                comboBox_class_name.Text = "";
                comboBox_student_id.Items.Clear();
                comboBox_student_id.Text = "";
                lable_student_name.Text = "姓名";
            }
            else if (changedComboBox == comboBox_class_name)
            {
                comboBox_student_id.Items.Clear();
                comboBox_student_id.Text = "";
                lable_student_name.Text = "姓名";
            }
        }

        private void UpdateDependentComboboxes(string nextInfoName)
        {
            //递归更新
            isProcessing = true;
            try
            {
                switch (nextInfoName)
                {
                    case "department_info":
                        RequestData(nextInfoName, comboBox_department_name, share_info.user_manage_department, "department_name", "department_id");
                        UpdateDependentComboboxes("subject_info");
                        break;
                    case "subject_info":
                        RequestData(nextInfoName, comboBox_subject_name, share_info.user_manage_subject, "subject_name", "subject_id");
                        UpdateDependentComboboxes("class_info");
                        break;
                    case "class_info":
                        RequestData(nextInfoName, comboBox_class_name, share_info.user_manage_class, "class_name", "class_id");
                        UpdateDependentComboboxes("not_have_card_stu_info");
                        break;
                    case "not_have_card_stu_info":
                        comboBox_student_id.Items.Clear() ;
                        comboBox_student_id.Text = "";
                        lable_student_name.Text = "";
                        RequestData(nextInfoName, comboBox_student_id, share_info.user_manage_student, "student_id", "student_name");
                        if (comboBox_student_id.Items.Count != 0)
                        {
                            comboBox_student_id.SelectedIndex = 0;
                            lable_student_name.Text = "姓名：" + share_info.user_manage_student[comboBox_student_id.Text];
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                // Log error or show message
            }
            finally
            {
                isProcessing = false;
            }
        }

 



        private void button1_Click(object sender, EventArgs e)
        {
            card_id.Text = "2023520868";
            log_text.SelectionColor = Color.Red;
            log_text.AppendText(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + "NEW" + Environment.NewLine);
        }

        private void 配置串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_portconf.Visible = true;
            PortName.Items.Clear();
            string[] ports = SerialPort.GetPortNames();//获取计算机可用串口
            if (ports.Length > 0)
            {
                PortName.Items.AddRange(ports);
                PortName.SelectedIndex = 0;
                BaudRate.Text = "4800";
               
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port_name = PortName.Text.Trim();
            port_baudrate = int.Parse(BaudRate.Text);
            port.PortName = port_name;
            port.BaudRate = port_baudrate;
            Serialport.open_usrt(port);
            panel_portconf.Visible = false;
        }


        private void commit_Click(object sender, EventArgs e)
        {
            if (!card_id.Text.Equals("") && !comboBox_student_id.Text.Equals(""))
            {
      
               var result= requirt_add_card(card_id.Text, comboBox_student_id.Text);
                if (result){
            
                }
                
            }
            else {
                MessageBox.Show("请先获取学号/卡号", "提示");
            }
           
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
            if (data.Length == 15) {
                this.buffer.Clear();
                return;
            }
        
            if (data.Length >= 16)
            {
         
            
            
                if (data.StartsWith("ok") && data[15] == '#')
                {           
                    string read_card_ok = data.Substring(2, 10);
                    this.buffer.Clear();
                    if (read_card_ok.Equals(read_card_ok_flag) )
                    {
                        return;
                    }
                    read_card_id_flag = read_card_ok;

                    log_text.Invoke((MethodInvoker)delegate
                    {               
                        log_text.SelectionColor = Color.Green;
                        log_text.AppendText($"{DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ")}Rfid_reader: 成功与：{read_card_ok}"+" 绑定" + Environment.NewLine);
                     
                    });

                }
                else if (data.StartsWith("cardid")  && data[15] == '#')
                {
                  

                    string read_card_id = data.Substring(6, 8);
                
                    this.buffer.Clear();
                    
                    if (read_card_id.Equals(read_card_id_flag)) {
                        return;
                    }
                    read_card_id_flag = read_card_id;
                    log_text.Invoke((MethodInvoker)delegate
                    {
                        card_id.Text = read_card_id;
                        log_text.SelectionColor = Color.Green;
                        log_text.AppendText($"{DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ")}Rfid_reader: 读取到卡号：{read_card_id}" + Environment.NewLine);
                    });
                }
            }

        }

        private void SendCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Serialport.close_usrt(port); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_portconf.Visible = false;
        }

        private void log_text_TextChanged(object sender, EventArgs e)
        {
            log_text.SelectionStart = log_text.Text.Length; 
            log_text.ScrollToCaret(); 

        }

        private void load_sno_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
