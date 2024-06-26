using CqustRfidSystem.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CqustRfidSystem
{
    public partial class logincs : Form
    {
        public logincs()
        {
            InitializeComponent();
        }

        private bool is_pwd_visible_flag;
        private void pictureBox_is_pwd_visible_Click(object sender, EventArgs e)
        {
            if (is_pwd_visible_flag == false)
            {
                pictureBox_is_pwd_visible.Image = Properties.Resources.eye;
                pictureBox_left.Image = Properties.Resources.开眼1;
                pictureBox_right.Image = Properties.Resources.开眼;
                is_pwd_visible_flag = true;
                user_password.PasswordChar = '\0';

            }
            else
            {
                pictureBox_is_pwd_visible.Image = Properties.Resources.eye1;
                pictureBox_left.Image = Properties.Resources.闭眼1;
                pictureBox_right.Image = Properties.Resources.闭眼;
                is_pwd_visible_flag = false;
                user_password.PasswordChar = '*';
            }
        }

        private void login_but_Click(object sender, EventArgs e)
        {

            if (user_id.Text == "" || user_password.Text == "")
            {
                MessageBox.Show("用户名或密码为空\n请输入用户名及密码", "提示");
            }
            else
            {   //合法性检验
                Regex zh = new Regex(@"[0-9]{10}");
                if (zh.IsMatch(user_id.Text) == false)
                {
                    MessageBox.Show("账号不合法\r\n应为10位纯数字职工号", "提示");
                    user_id.Clear();
                    user_password.Clear();

                }
                else
                {
                    var postData = new Dictionary<string, object>{
                    {"user_id", user_id.Text},{"user_pwd", user_password.Text}};
                    var response = Httpx.Post(Config.BASE_URL + "/login", postData);
                    if (response.TryGetValue("flag", out object flagValue))
                    {
                        string flag = flagValue.ToString();
                        switch (flag)
                        {
                            case Config.FLAG_ERROR:
                                MessageBox.Show("请求错误", "警告");
                                break;
                            case Config.FLAG_USER_NOT_EXIST:
                                MessageBox.Show("用户不存在", "警告");
                                break;
                            case Config.FLAG_LOGIN_ERR:
                                MessageBox.Show("账号或密码错误", "警告");
                                break;
                            case Config.FLAG_LOGIN_ERR_MAX:
                                MessageBox.Show("登录错误次数过多，请稍后再试", "警告");
                                break;
                            case Config.FLAG_OK:
                                if (response.TryGetValue("data", out object dataValue2) && dataValue2 is JObject dataObject2)
                                {
                                    if (dataObject2.TryGetValue("user_name", out var userNameValue2) && userNameValue2 is JValue userNameJValue2)
                                    {
                                        string user_name = userNameJValue2.Value.ToString();
                                        share_info.user_name = user_name;
                                    

                                    }
                                    if (dataObject2.TryGetValue("user_power", out var userPowerValue2) && userPowerValue2 is JValue userPowerJValue2)
                                    {
                                        string user_power = userPowerJValue2.Value.ToString();
                                        share_info.user_power = user_power;
                                    
                                    }
                                    if (dataObject2.TryGetValue("user_school_id", out var usersidValue2) && usersidValue2 is JValue usersidJValue2)
                                    {
                                        string user_school_id = usersidJValue2.Value.ToString();
                                        share_info.user_school = user_school_id;

                                    }
                                    share_info.user_id = user_id.Text;
                                    MainForm mf = new MainForm();
                                    mf.Show();
                                    this.Hide();
                                
                                   
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void pictureBox_title_Click(object sender, EventArgs e)
        {

        }
    }
}
