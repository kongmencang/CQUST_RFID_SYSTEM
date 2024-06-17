import time

from conflig import MYSQL_USERNAME, MYSQL_PASSWORD, MYSQL_HOST, MYSQL_DATABASE
from mysql.CqustCardSystemMysql import CqustCardSystemMysql

mysql = CqustCardSystemMysql(MYSQL_USERNAME,MYSQL_PASSWORD,MYSQL_DATABASE,MYSQL_HOST)

#cqust_cart_system_mysql.is_card_exeit(sno="2023520868" ,card_id= "429E40E7")
sno="2023520868"
card_id= "429E40E7"

# # a=mysql.get_techer_id_and_course_id_by_time_and_scheduling_id('2','1253')
# a=mysql.get_stu_scheduling_id_by_sno("")
# print(a)

# print(mysql.get_stu_is_attendence_info_by_time(sno, '2024-06-15 20:06:00', '2024-06-15 20:06:28'))


# print(mysql.get_all_school_name_from_school_info())


