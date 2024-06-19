import os
"""
项目路径
"""
#运行路径
PROJECT_PATH = os.path.dirname(os.path.abspath(__file__))

"""
Mysql配置
"""
#用户名
MYSQL_USERNAME='root'
#密码
MYSQL_PASSWORD='yk1184507696'
#地址
MYSQL_HOST='47.109.137.143'
#数据库名
MYSQL_DATABASE='CqustRfidSystem'
#RFID卡信息表名
MYSQL_RFID_INFO_TABLE='rfid_info'
#学生信息表名
MYSQL_STU_INFO_TABLE='student_info'
#用户信息表
MYSQL_USER_INFO_TABLE='user_info'

#学生选课表
MYSQL_STU_COURSE_SELECTION_INFO_TABLE='stu_course_selection_info'
#课程开设信息表
MYSQL_SCHEDULING_INFO_TABLE = 'scheduling_info'
#考勤信息表
MYSQL_ATTENDENCE_INFO_TABLE = 'attendance_info'
#教师信息表
MYSQL_TEACHER_INFO_TABLE = 'teacher_info'
#学院信息表
MYSQL_SCHOOL_INFO_TABLE = 'school_info'
#系信息表
MYSQL_DEPARTMENT_INFO_TABLE = 'department_info'
#专业信息表
MYSQL_SUBJECT_INFO_TABLE = 'subject_info'
#班级信息表
MYSQL_CLASS_INFO_TABLE = 'class_info'
"""
用户账号状态
"""
#正常
USER_STATE_NORMAL = '1'
#封禁
USER_STATE_PENDING = '0'


"""
状态码 最好不要改它
"""
FLAG_OK= "111111" #表示接口返回一切正常
FLAG_ERROR ="000000" #通用错误码
# 用户登录相关
FLAG_USER_NOT_EXIST= "000001" #表示登录用户名不存在
FLAG_LOGIN_ERR="000002"# 表示登录失败
FLAG_LOGIN_ERR_MAX ="000003"# 表示错误次数过多 暂时禁止登录


#rfid卡片相关
FLAG_USER_HAVE_CARD ="000004" #表示该用户已经有卡了
FLAG_CARD_IS_USING="000005" #表示卡片已有归属
FLAG_ADD_CARD_NOT_SUCCESS="000006" #表示卡片注册失败

#学生相关
FLAG_NOT_STUDENT="000007" #表示学生不存在

#考勤相关
FLAG_NOT_IN_ATTENDANCE_TIME = '000008'# 表示不在考勤时间内
FLAG_THIS_TIME_STUDENT_NOT_COURSE='000009' #表示学生该时间没有课
FLAG_ADD_ATTENDANCE_NOT_SECCESS='000010' #打卡失败
FLAG_THIS_TIME_IS_ATTENDENCE='000011' #这个时间段已经打过卡了
"""
课程时间相关
"""

# 课程时间
COURSE_TIMES = [
    ("08:00:00", "10:10:00"), #第一节课开始结束时间
    ("10:30:00", "12:10:00"),
    ("14:00:00", "15:40:00"),
    ("16:00:00", "17:40:00"),
    ("18:00:00", "19:40:00"),
    ("21:40:00", "21:40:00"),#第六节课开始结束时间
]
COURSE_TIMES = [
    ("08:00:00", "10:10:00"), #第一节课开始结束时间
    ("10:30:00", "12:10:00"),
    ("14:00:00", "15:40:00"),
    ("16:00:00", "17:40:00"),
    ("20:20:00", "21:40:00"),
    ("21:40:00", "21:40:00"),#第六节课开始结束时间
]
# 缺勤时间（分钟）
COURSE_ABSENCE_TIME = 15
# 迟到时间
COURSE_LATE_TIME = 5
#打卡开放时间
COURSE_AGAIN_TIME = 5
# 打卡关闭时间
COURSE_ABSENCE_TIME = 20

TERM_TIME= "202301"