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
MYSQL_PASSWORD=''
#地址
MYSQL_HOST=''
#数据库名
MYSQL_DATABASE='CqustRfidSystem'
#RFID卡信息表名
MYSQL_RFID_INFO_TABLE='rfid_info'
#学生信息表名
MYSQL_STU_INFO_TABLE='student_info'
#用户信息表
MYSQL_USER_INFO_TABLE='user_info'




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


FLAG_USER_NOT_EXIST= "000001" #表示登录用户名不存在
FLAG_LOGIN_ERR="000002"# 表示登录用户名不存在
FLAG_LOGIN_ERR_MAX ="000003"# 表示错误次数过多 暂时禁止登录
