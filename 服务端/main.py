import time
from datetime import timedelta, datetime

from conflig import *
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

def query_scheduling_info():
    ans = []
    # 这一次查询的目的是找出这个时间点的课程
    sql1 = "select course_id, scheduling_id, place from scheduling_info where weekday = 3 and course_section = 5 and state = 1"
    result1 = mysql.base_select_sql(sql1)
    if not result1:
        return []
    for course_id, scheduling_id, place in result1:
        #这异常查询的目的是找出选修这些课程的学生
        sql2 = "select sno from stu_course_selection_info where course_id = %s"
        result2 = mysql.base_select_sql(sql2, (course_id,))
        if not result2:
            continue
        for (sno,) in result2:
            # 如果这些学生没有在签到表中，就视为缺勤 记录入表。
            sql3 = """
                select * from attendance_info 
                where substring_index(addtime, ' ', 1) = '2024-06-19' 
                and sno = %s 
                and scheduling_id = %s 
                and course_sections = 5
            """
            result3 = mysql.base_select_sql(sql3, (sno, scheduling_id))

            if not result3:
                ans.append({
                    'sno': sno,
                    'course_sections': 5,
                    'scheduling_id': scheduling_id,
                    'place': place
                })
    return ans




a=query_scheduling_info()
for i in a:
    print(i)