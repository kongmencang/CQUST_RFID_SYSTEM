using CqustRfidSystem.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CqustRfidSystem
{
    public partial class SendCard : Form
    {

        private StringBuilder buffer = new StringBuilder();

        string get_info_url = Config.BASE_URL + "get_info";
        public SendCard()
        {
            InitializeComponent();
        }


      



        private void SendCard_Load(object sender, EventArgs e)
        {
            switch (share_info.user_power) {
                //最高权限 系统超级管理员
                case "0": {
                        //请求学院
                         var postData = new Dictionary<string, object>{
                         { "info_name", "school_info" }
                        };
                        var response =  Httpx.Post(get_info_url, postData);
                        if (response != null)
                        {
                            if (response.TryGetValue("flag", out object flagValue))
                            {
                                string flag = flagValue.ToString();
                                switch (flag)
                                {
                                    case Config.FLAG_ERROR: { MessageBox.Show("请求错误","警告"); break; }
                                    case Config.FLAG_OK:
                                        {
                                            if (response.TryGetValue("data", out object dataValue) && dataValue is JArray dataArray)
                                            {
                                                foreach (var item in dataArray)
                                                {
                                                    var school_info = item.ToObject<Dictionary<string, string>>();
                                                    comboBox_school_name.Items.Add(school_info["school_name"]);
                                                    //存起来 以后好用
                                                    share_info.user_manage_school[school_info["school_name"]] = school_info["school_id"]; 


                                                }
                                            }
                                       
                                            comboBox_school_name.SelectedIndex = 0;
                                           break; }

                                }
                            }                     
                        }
                        //请求系
                     
                       postData = new Dictionary<string, object>
                       {
                            { "info_name", "department_info" },
                            { "info_argument", new Dictionary<string, string> { { "school_id", share_info.user_manage_school[comboBox_school_name.Text] } } }
                                                };
                        response = Httpx.Post(get_info_url, postData);
                        if (response != null)
                        {
                            if (response.TryGetValue("flag", out object flagValue))
                            {
                                string flag = flagValue.ToString();
                                switch (flag)
                                {
                                    case Config.FLAG_ERROR: { MessageBox.Show("请求错误", "警告"); break; }
                                    case Config.FLAG_OK:
                                        {
                                            if (response.TryGetValue("data", out object dataValue) && dataValue is JArray dataArray)
                                            {
                                                foreach (var item in dataArray)
                                                {
                                                    var department_info = item.ToObject<Dictionary<string, string>>();
                                                    comboBox_department_name.Items.Add(department_info["department_name"]);
                                                    share_info.user_manage_department.Add(department_info["department_name"], department_info["department_id"]);

                                                }
                                            }
                                            comboBox_department_name.SelectedIndex = 0;
                                            break;
                                        }

                                }
                            }
                        }
                        //请求专业
                        postData = new Dictionary<string, object>
                       {
                            { "info_name", "subject_info" },
                            { "info_argument", new Dictionary<string, string> { { "department_id", share_info.user_manage_department[comboBox_department_name.Text] } } }
                                                };
                        response = Httpx.Post(get_info_url, postData);
                        if (response != null)
                        {
                            if (response.TryGetValue("flag", out object flagValue))
                            {
                                string flag = flagValue.ToString();
                                switch (flag)
                                {
                                    case Config.FLAG_ERROR: { MessageBox.Show("请求错误", "警告"); break; }
                                    case Config.FLAG_OK:
                                        {
                                            if (response.TryGetValue("data", out object dataValue) && dataValue is JArray dataArray)
                                            {
                                                foreach (var item in dataArray)
                                                {
                                                    var subject_info = item.ToObject<Dictionary<string, string>>();
                                                    comboBox_subject_name.Items.Add(subject_info["subject_name"]);
                                                    share_info.user_manage_subject.Add(subject_info["subject_name"], subject_info["subject_id"]);

                                                }
                                            }
                                            comboBox_subject_name.SelectedIndex = 0;
                                            break;
                                        }
                                }
                            }
                        }
                        //请求班
                        postData = new Dictionary<string, object>
                       {
                            { "info_name", "class_info" },
                            { "info_argument", new Dictionary<string, string> { { "subject_id", share_info.user_manage_subject[comboBox_subject_name.Text] } } }
                                                };
                        response = Httpx.Post(get_info_url, postData);
                        if (response != null)
                        {
                            if (response.TryGetValue("flag", out object flagValue))
                            {
                                string flag = flagValue.ToString();
                                switch (flag)
                                {
                                    case Config.FLAG_ERROR: { MessageBox.Show("请求错误", "警告"); break; }
                                    case Config.FLAG_OK:
                                        {
                                            if (response.TryGetValue("data", out object dataValue) && dataValue is JArray dataArray)
                                            {
                                                foreach (var item in dataArray)
                                                {
                                                    var class_info = item.ToObject<Dictionary<string, string>>();
                                                    comboBox_class_name.Items.Add(class_info["class_name"]);
                                                    share_info.user_manage_class.Add(class_info["class_name"],class_info["class_id"]);

                                                }
                                            }
                                            comboBox_class_name.SelectedIndex = 0;
                                            break;
                                        }
                                }
                            }
                        }

                        break;
                    }
            }
        }

        private void commit_Click(object sender, EventArgs e)
        {
            card_id.Text="2023520868";
            string send_data = "r"+ card_id.Text.Trim()+"0000#";
            Serialport.send_string_to_byte_data(uart,send_data);


        }

        private void uart_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort uart = (SerialPort)sender;
            int bytesToRead = uart.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            uart.Read(buffer, 0, bytesToRead);

            // 将接收到的字节添加到缓冲区中
            foreach (byte b in buffer)
            {
                this.buffer.Append((char)b);
            }

            // 检查缓冲区是否包含完整的消息
            string data = this.buffer.ToString();
            

            if (data.Substring(0,5).Equals("cqust") && data[15].Equals('#'))
            {
                data =data.Substring(5,10);
                this.buffer.Clear();
                // 将消息添加到 TextBox 控件
                textBox1.Invoke((MethodInvoker)delegate {
                    MessageBox.Show(data);
                    //收到
                    textBox1.AppendText("读卡：" + data + "\r\n");
                });
            }

            if (data.Substring(0,2).Equals("ok") && data[15].Equals('#'))
            {
                data = data.Substring(2, 12);
                this.buffer.Clear();
                textBox1.Invoke((MethodInvoker)delegate {
               
                });
            }

         
            if (data.Substring(0, 6).Equals("cardid") && data[15].Equals('#'))
            {
             
                data=data.Substring(6, 8);
                this.buffer.Clear();
                // 将消息添加到 TextBox 控件
                textBox1.Invoke((MethodInvoker)delegate {
              
                });
            }

        }
    }
}
