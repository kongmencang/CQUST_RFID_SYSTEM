using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqustRfidSystem
{
    internal class share_info
    {
        //用户相关
        public static string user_power="3";
        public static string user_name;
        public static string user_id= "0101000002";
        public static string user_school= "0100000000";
        //排课信息
        public static JArray scheduling_info= new JArray();

        //用户可管理对象
        public static Dictionary<string,string> user_manage_school =new Dictionary<string,string>();
        public static Dictionary<string, string> user_manage_department = new Dictionary<string, string>();
        public static Dictionary<string, string> user_manage_subject = new Dictionary<string, string>();
        public static Dictionary<string, string> user_manage_class = new Dictionary<string, string>();
        public static Dictionary<string, string> user_manage_student = new Dictionary<string, string>();
    }
}
