using CqustRfidSystem.Tool;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            if (share_info.user_power == "0")
            {
                RequestData("school_info", comboBox_school_name, share_info.user_manage_school, "school_name", "school_id");
               
            }
            if (share_info.user_power == "2") { 
                comboBox_department_name.Enabled = false;
                comboBox_subject_name.Enabled = false;
                comboBox_class_name.Enabled = false;           
                //获取学院名
                var dataArray = get_info("school_info", new Dictionary<string, string> { { "school_id", share_info.user_school } });
                comboBox_school_name.Items.Add(dataArray[0].ToObject<Dictionary<string, string>>()["school_name"]);              
                comboBox_school_name.SelectedIndex = 0;
                //获取老师所教的课的排课id
                dataArray = get_info("scheduling_info", new Dictionary<string, string> { { "teacher_id", share_info.user_id } });
                share_info.scheduling_info = dataArray;
                foreach(var item in dataArray){
                    comboBox_scheduling_id.Items.Add(item.ToObject<Dictionary<string, string>>()["scheduling_id"]);            
                }
                comboBox_scheduling_id.Items.Add("");
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

        }
    }
}
