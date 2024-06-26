using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CqustRfidSystem
{
    public static class Config
    {
        //请求地址
        public const string BASE_URL = "http://chapaofan.cn/";


        /*
         状态码
       */
        public const string FLAG_OK = "111111"; // 表示接口返回一切正常
        public const string FLAG_ERROR = "000000"; // 通用错误码

        // 用户登录相关
        public const string FLAG_USER_NOT_EXIST = "000001"; // 表示登录用户名不存在
        public const string FLAG_LOGIN_ERR = "000002"; // 表示登录用户名不存在
        public const string FLAG_LOGIN_ERR_MAX = "000003"; // 表示错误次数过多 暂时禁止登录

        // rfid卡片相关
        public const string FLAG_USER_HAVE_CARD = "000004"; // 表示该用户已经有卡了
        public const string FLAG_CARD_IS_USING = "000005"; // 表示卡片已有归属
        public const string FLAG_ADD_CARD_NOT_SUCCESS = "000006"; // 表示卡片注册失败

        // 学生相关
        public const string FLAG_NOT_STUDENT = "000007"; // 表示学生不存在

        // 考勤相关
        public const string FLAG_NOT_IN_ATTENDANCE_TIME = "000008"; // 表示不在考勤时间内
        public const string FLAG_THIS_TIME_STUDENT_NOT_COURSE = "000009"; // 表示学生该时间没有课
        public const string FLAG_ADD_ATTENDANCE_NOT_SUCCESS = "000010"; // 表示考勤记录添加失败
        public const string FLAG_THIS_TIME_IS_ATTENDANCE = "000011"; // 表示当前时间已考勤

  
        


    }
}
