using CqustRfidSystem.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CqustRfidSystem
{
    public partial class Attendence_info_manage : Form
    {
        public Attendence_info_manage()
        {
            InitializeComponent();
        }
        string get_info_url = Config.BASE_URL + "get_info";

        private bool isProcessing = false;

        Dictionary<string, string> argument = new Dictionary<string, string>();

        Dictionary<string, string> state_flag = new Dictionary<string, string>();


        private JArray get_info(string infoName, Dictionary<string, string> infoArguments)
        {
            var postData = new Dictionary<string, object>
    {
        { "info_name", infoName },
        { "info_argument", infoArguments }
    };

            var response = Httpx.Post(get_info_url, postData);

            if (response != null && response.TryGetValue("flag", out object flagValue))
            {
                string flag = flagValue.ToString();
                if (flag == Config.FLAG_ERROR)
                {
                    MessageBox.Show("请求错误", "警告");
                    return null;
                }
                 if (flag == Config.FLAG_OK && response.TryGetValue("data", out object dataValue) && dataValue is JArray dataArray)
                {
                   
                    return dataArray;
                }
            }

            return null;
        }

        private void Attendence_info_manage_Load(object sender, EventArgs e)
        {
            state_flag.Add("正常", "0");
            state_flag.Add("迟到","1");
            state_flag.Add("缺勤", "2");


            monthCalendar1.Visible = false;
            monthCalendar2.Visible = false;
            if (share_info.user_power == "0")
            {
                RequestData("school_info", comboBox_school_name, share_info.user_manage_school, "school_name", "school_id");
               
            }
            if (share_info.user_power == "2") { //授课教师
                comboBox_department_name.Enabled = false;
                comboBox_subject_name.Enabled = false;
                comboBox_class_name.Enabled = false;           
                //获取学院名
               
                try
                {
                    var dataArray = get_info("school_info", new Dictionary<string, string> { { "school_id", share_info.user_school } });
                    comboBox_school_name.Items.Add(dataArray[0].ToObject<Dictionary<string, string>>()["school_name"]);
                    comboBox_school_name.SelectedIndex = 0;
                    //获取老师所教的课的排课id
                    dataArray = get_info("scheduling_info", new Dictionary<string, string> { { "teacher_id", share_info.user_id } });
                    share_info.scheduling_info = dataArray;
                    foreach (var item in dataArray)
                    {
                        comboBox_scheduling_id.Items.Add(item.ToObject<Dictionary<string, string>>()["scheduling_id"]);
                    }
                    comboBox_scheduling_id.Items.Add("");
                }
                catch { 
                }
                       
             
            }
            if (share_info.user_power == "3") {//辅导员
                comboBox_department_name.Enabled = false;
                comboBox_subject_name.Enabled = false;
                comboBox_scheduling_id.Enabled = false;
                try
                {
                    var dataArray = get_info("school_info", new Dictionary<string, string> { { "school_id", share_info.user_school } });
                    comboBox_school_name.Items.Add(dataArray[0].ToObject<Dictionary<string, string>>()["school_name"]);
                    comboBox_school_name.SelectedIndex = 0;
                    //获取所带班级
                    dataArray = get_info("class_info", new Dictionary<string, string> { { "counsellor_id", share_info.user_id } });
                    foreach (var item in dataArray)
                    {
                        comboBox_class_name.Items.Add(item.ToObject<Dictionary<string, string>>()["class_name"]);
                    }
                    comboBox_class_name.Items.Add("");
                }
                catch
                {
                }
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
                    comboBox.Items.Add("");
                    storageDict.Clear();
                    foreach (var item in dataArray)
                    {
                        var info = item.ToObject<Dictionary<string, string>>();
                        comboBox.Items.Add(info[displayName]);
                        storageDict[info[displayName]] = info[idName];
                    }
                    if (infoName == "school_info")
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

            }
            else if (changedComboBox == comboBox_department_name)
            {
                comboBox_subject_name.Items.Clear();
                comboBox_subject_name.Text = "";
                comboBox_class_name.Items.Clear();
                comboBox_class_name.Text = "";

            }
            else if (changedComboBox == comboBox_subject_name)
            {
                comboBox_class_name.Items.Clear();
                comboBox_class_name.Text = "";

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

        private void comboBox_school_name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                ClearDependentComboboxes(comboBox_school_name);
                UpdateDependentComboboxes("department_info");
            }
        }

        private void comboBox_scheduling_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_scheduling_id.Text == "")
            {
                label_course_name.Text = "";
            }
            else {
                var dataArray = get_info("course_name_info", new Dictionary<string, string> { { "scheduling_id", comboBox_scheduling_id.Text } });
            
                label_course_name.Text=dataArray[0].ToObject<Dictionary<string, string>>()["course_name"];
            }
            
               
           
            
        }

        private void load_sno_btn_Click(object sender, EventArgs e)
        {
            argument.Clear();
            argument.Add("school_name",comboBox_school_name.Text);
            argument.Add("department_name", comboBox_department_name.Text);
            argument.Add("subject_name", comboBox_subject_name.Text);
            argument.Add("class_name", comboBox_class_name.Text);
            argument.Add("weekday", comboBox_weekday.Text);
            argument.Add("course_sections", comboBox_course_section.Text);
            argument.Add("attendance_info.scheduling_id", comboBox_scheduling_id.Text);
            argument.Add("start_time", textBox_again_time.Text);
            argument.Add("end_time", textBox_end_time.Text);
            argument.Add("attendance_info.sno", textbox_sno.Text);
        
            if (comboBox_state.Text != "") {
                argument.Add("attendance_info.state", state_flag[comboBox_state.Text]);
            }
           
            if (share_info.user_power == "2") {
                argument.Add("teacher_info.teacher_id", share_info.user_id);
            }
            if (share_info.user_power == "3") {
                argument.Add("class_info.counsellor_id", share_info.user_id);
                // class_info.counsellor_id = '0101000002'
            }
            var dataArray = get_info("attendance_info", argument);
            data_table.Rows.Clear();//清处表格数据

            foreach (var i in dataArray)
            {
                //解析数据绘制表格
                int j = data_table.Rows.Add();

                data_table.Rows[j].Cells[0].Value = i["id"];
                data_table.Rows[j].Cells[1].Value = i["addtime"];
                data_table.Rows[j].Cells[2].Value = i["sno"];
                data_table.Rows[j].Cells[3].Value = i["sname"];
                data_table.Rows[j].Cells[4].Value = i["class_name"];
                data_table.Rows[j].Cells[5].Value = i["course_name"];
                data_table.Rows[j].Cells[6].Value = i["place"];
                data_table.Rows[j].Cells[7].Value = i["course_sections"];
                data_table.Rows[j].Cells[8].Value = i["teacher_name"];
                data_table.Rows[j].Cells[9].Value = i["counselor_name"];
                data_table.Rows[j].Cells[10].Value = i["state"];



            }

       
        }

        private void pictureBox_c1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
     
        }

        private void pictureBox_c2_Click(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

      
    

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime start = monthCalendar1.SelectionRange.Start;
            string s = start.ToString("yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture);
            textBox_again_time.Text = s;
            monthCalendar1.Visible = false;

        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime start = monthCalendar1.SelectionRange.Start;
            string s = start.ToString("yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture);
            textBox_end_time.Text = s;
            monthCalendar2.Visible = false;
        }
    }
    
}
