using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CqustRfidSystem
{
    public partial class SendCard : Form
    {

        private StringBuilder buffer = new StringBuilder();

        public SendCard()
        {
            InitializeComponent();
        }

        private void SendCard_Load(object sender, EventArgs e)
        {
            
        }

        private void commit_Click(object sender, EventArgs e)
        {
            card_id.Text="2023520868";
            string send_data = "w"+ card_id.Text.Trim()+"0000#";
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
                data = data.Substring(5, 15);
                this.buffer.Clear();
                // 将消息添加到 TextBox 控件
                textBox1.Invoke((MethodInvoker)delegate {
                    //收到
                    textBox1.AppendText("正在写入：" + data + "\n");
                });
            }

            if (data.Substring(0,2).Equals("ok") && data[15].Equals('#'))
            {
                data = data.Substring(2, 12);
                this.buffer.Clear();
                // 将消息添加到 TextBox 控件
                textBox1.Invoke((MethodInvoker)delegate {
                    textBox2.AppendText("\r\n写入成功：" + data);
                });
            }

            if (data.Substring(0, 6).Equals("cardid") && data[15].Equals('#'))
            {
             
                data=data.Substring(6, 8);

             
                
                this.buffer.Clear();
                // 将消息添加到 TextBox 控件
                textBox1.Invoke((MethodInvoker)delegate {
                    textBox2.AppendText("\r\n卡id：" + data);
                });
            }

        }
    }
}
