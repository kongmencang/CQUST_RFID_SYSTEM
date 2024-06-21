import threading


from conflig import *
from dispose.Attendance import Attendance
from mysql.CqustCardSystemMysql import CqustCardSystemMysql
from www import router

mysql = CqustCardSystemMysql(MYSQL_USERNAME,MYSQL_PASSWORD,MYSQL_DATABASE,MYSQL_HOST)

#cqust_cart_system_mysql.is_card_exeit(sno="2023520868" ,card_id= "429E40E7")
sno="2023520868"
card_id= "429E40E7"

# # a=mysql.get_techer_id_and_course_id_by_time_and_scheduling_id('2','1253')
# a=mysql.get_stu_scheduling_id_by_sno("")
# print(a)

# print(mysql.get_stu_is_attendence_info_by_time(sno, '2024-06-15 20:06:00', '2024-06-15 20:06:28'))


# print(mysql.get_all_school_name_from_school_info())






# a=query_scheduling_info()
# for i in a:
#     print(i)

# current_datetime = datetime.now()
# weekday = current_datetime.weekday()+1
# now=current_datetime.strftime("%Y-%m-%d")
# print(now)





if __name__ == '__main__':
    # 开启自动打卡线程
    # scheduler_thread = threading.Thread(target=Attendance.auto_attendance)
    # scheduler_thread.daemon = True
    # scheduler_thread.start()
    # 启动路由
    router.run()