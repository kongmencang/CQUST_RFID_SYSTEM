using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CqustRfidSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (share_info.user_power != "0") {
                add_card.Enabled = false;
                label1.Visible = true;
                label2.Visible=true;
                attandence_conf.Enabled = false;
            }
            String s="";
            if (share_info.user_power == "0") s = "超级管理员";
            if (share_info.user_power == "1") s = "系管理员";
            if (share_info.user_power == "2") s = "教师";
            if (share_info.user_power == "3") s = "辅导员"; ;
            s1.Text = string.Format("欢迎{0:G}:{1:G}",s, share_info.user_name);
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            s2.Alignment = ToolStripItemAlignment.Right;
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SendCard sendCard = new SendCard();
            sendCard.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Attendence conf = new Attendence();
            conf.Show();
        }

      

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Attendence_info_manage attendence_Info_Manage = new Attendence_info_manage();
            attendence_Info_Manage.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            s2.Text = string.Format("当前系统时间:{0:G}", time);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
