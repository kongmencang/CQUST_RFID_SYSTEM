import threading
from datetime import datetime, timedelta
import time
from conflig import *
from dispose import mysql_cqust_rfid
from tool.Email import Email


class Attendance:


    """
    打卡相关业务处理
    """
    @classmethod
    def __get_course_status(cls,time_str):
        """
        打卡时间计算
        :param time_str:打卡时间
        :return:{flag:0：正常 1迟到 2缺勤 ,section:1-6对应课程节数}
        """
        input_time = datetime.strptime(time_str, "%H:%M:%S").time()
        for i, (start_time_str, end_time_str) in enumerate(COURSE_TIMES):
            start_time = datetime.strptime(start_time_str, "%H:%M:%S").time()
            end_time = datetime.strptime(end_time_str, "%H:%M:%S").time()
            # 打卡时间点
            again_time = (datetime.combine(datetime.today(), start_time) - timedelta(minutes=COURSE_AGAIN_TIME)).time()
            # 迟到时间点
            late_time = (datetime.combine(datetime.today(), start_time) + timedelta(minutes=COURSE_LATE_TIME)).time()
            # 缺勤时间点
            absence_time = (
                        datetime.combine(datetime.today(), start_time) + timedelta(minutes=COURSE_ABSENCE_TIME)).time()
            # 判断输入时间在哪个时间段
            if again_time <= input_time < late_time:
                return {'flag': 0, 'section': i+1}
            elif late_time <= input_time < absence_time:
                return {'flag': 1, 'section': i+1}
            elif absence_time <= input_time < end_time:
                return {'flag': 2, 'section': i+1}
        return {'flag':-1}

    @classmethod
    def __add_attendance_info(cls,sno,course_sections,scheduling_id,state,place):
        addtim=time.strftime('%Y-%m-%d %H:%M:%S', time.localtime())
        result= mysql_cqust_rfid.add_attendence_to_attendence_info(addtim,sno,course_sections,scheduling_id,state,place)
        return result




    @classmethod
    def attendance(cls,sno,time_str,place):
        """
        打卡业务方法
        :param sno: 学号
        :param card_id: 卡号
        :param time_str: 时间点 00:00:00
        :param attendance_achine_id: 考勤机编号
        :return:
        """
        dic={}
        #获取到时间属于第几节课
        course_section = cls.__get_course_status(time_str)

        if course_section['flag'] == -1:
            return {"flag":FLAG_NOT_IN_ATTENDANCE_TIME}
        #获取学生的所有课程
        stu_courses = mysql_cqust_rfid.get_stu_course_id_id_by_sno(sno)
        if not stu_courses:
            return {'flag':FLAG_THIS_TIME_STUDENT_NOT_COURSE}
        # 用来检查是否有课程可以打开
        flag=0
        #遍历一下学生的课程id，看存不存在当前这个时间点的课
        for i in stu_courses:
            #节次 地点 课程ID 星期几
            result=mysql_cqust_rfid.get_techer_id_and_scheduling_id_by_time_and_course_id_and_place(course_section=course_section['section'],course_id=i,place=place)
            if result:
                start_time = (datetime.combine(datetime.today(), datetime.strptime(time.strftime('%Y-%m-%d ', time.localtime())+COURSE_TIMES[course_section['section']-1][0], "%Y-%m-%d %H:%M:%S").time() ) - timedelta(
                    minutes=COURSE_AGAIN_TIME))
                end_time=(datetime.combine(datetime.today(),datetime.strptime(time.strftime('%Y-%m-%d ', time.localtime())+COURSE_TIMES[course_section['section']-1][1], "%Y-%m-%d %H:%M:%S").time()) + timedelta(
                    minutes=COURSE_ABSENCE_TIME))
                #是不是已经签到了
                res = mysql_cqust_rfid.get_stu_is_attendence_info_by_time(sno, start_time, end_time)
                if(res):
                    return {'flag':FLAG_THIS_TIME_IS_ATTENDENCE}
                #state 取值 0正常  1迟到 2缺勤
                res = cls.__add_attendance_info(sno,course_section['section'],result['scheduling_id'],course_section['flag'],place)
                if res:
                    stu_name =mysql_cqust_rfid.get_stu_name_by_sno(sno)

                    return {'flag':FLAG_OK,'data':{'stu_name':stu_name,"state":course_section['flag']}}
                else:
                    return {'flag':FLAG_ADD_ATTENDANCE_NOT_SECCESS}
        return {'flag':FLAG_THIS_TIME_STUDENT_NOT_COURSE}

    @classmethod
    def auto_attendance(cls):
        while True:
            now = datetime.now()
            # 调度当天的打卡任务
            for i, (start_time_str, _) in enumerate(COURSE_TIMES):
                start_time = datetime.strptime(start_time_str, "%H:%M:%S")

                card_open_time = now.replace(hour=start_time.hour, minute=start_time.minute,
                                                second=start_time.second,
                                                microsecond=0)
                card_open_time += timedelta(minutes=COURSE_ABSENCE_TIME)

                # 计算等待时间
                wait_time = (card_open_time - now).total_seconds()
                if wait_time > 0:
                    # 开一个线程等待打卡
                    threading.Timer(wait_time, cls.__absence_dispose, args=(i+1,)).start()
                else:
                    cls.__absence_dispose(i + 1)
                    pass
                    #
                    # #为什么我会这么写呢，我也不知道 反正没打卡的就必须缺勤！就算系统关闭了，你也逃不掉，嘿嘿

            # 计算距离午夜的时间
            next_midnight = (now + timedelta(days=1)).replace(hour=0, minute=0, second=0, microsecond=0)
            seconds_until_midnight = (next_midnight - now).total_seconds()
            # 新的一天 开启新的打卡任务！
            time.sleep(seconds_until_midnight)

            #email_qq.send_email('1184507696@qq.com', "测试", "AA")
    @classmethod
    def __absence_dispose(cls,course_section):

        """
        缺勤处理函数
        :return:
        """
        #把没主动的学生插入打卡表 记为缺勤
        mysql_cqust_rfid.auto_insert_not_attendance_student_info(course_section)
        start_time = time.strftime(f'%Y-%m-%d {COURSE_TIMES[course_section - 1][0]}', time.localtime())
        end_time = time.strftime(f'%Y-%m-%d {COURSE_TIMES[course_section - 1][1]}', time.localtime())
        # start_time='2024-06-20 14:00:33'
        # end_time='2024-06-20 14:50:33'
        #找这个时间点所有缺勤的学生和对应的排课编号
        sno_list= mysql_cqust_rfid.get_absence_student_sno_and_scheduling_id_by_time(start_time,end_time)
        sno_list=list(set(sno_list))
        data=[]
        for i in sno_list:
            #获取学生姓名班级 辅导员和授课教师
            result=mysql_cqust_rfid.get_student_name_class_name_counsellor_name_by_sno(i[0])
            result["course_name"]=mysql_cqust_rfid.get_course_name_by_scheduling_id(i[1])
            data.append(result)

        result = {}
        #重组数据结构
        for item in data:
            counsellor = item['counsellor_name']
            course = item['course_name']
            class_name = item['class_name']
            sname = item['sname']

            if counsellor not in result:
                result[counsellor] = {}

            if course not in result[counsellor]:
                result[counsellor][course] = ""
            # 拼接字符串
            if result[counsellor][course]:
                result[counsellor][course] += " ， "
            result[counsellor][course] += f"{class_name} {sname}"
        for counsellor in result.keys():
            for course in result[counsellor].keys():
                #构建html
                email_body = ABSENCE_EMAIL_MODE.render(
                    counsellor_name=counsellor,
                    student_names=result[counsellor][course],
                    again_time=start_time,
                    course_name=course
            )
                rsv_email = mysql_cqust_rfid.get_teacher_email_by_teacher_name(counsellor)
                #发邮件
                EMAIL_QQ.send_email(email_body=email_body,rsv_email=rsv_email,subject_text="学生缺勤通知")
                #邮件多线程要用线程池调度 太麻烦了 不想写
                #threading.Thread(target=EMAIL_QQ.send_email, args=(email_body, "学生缺勤通知", rsv_email)).start()

if __name__ == '__main__':
    Attendance.absence_dispose(1)


