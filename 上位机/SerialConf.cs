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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CqustRfidSystem
{
    public partial class SerialConf : Form
    {
        public SerialConf()
        {
            InitializeComponent();
        }

        private void commit_Click(object sender, EventArgs e)
        {
    
            MessageBox.Show("设置成功", "提示");
            this.Close();

        }

        private void SerialConf_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();//获取计算机可用串口
            if (ports.Length > 0)
            {
                PortName.Items.AddRange(ports);
                PortName.SelectedIndex = 0;

            }

        }
    }
}
