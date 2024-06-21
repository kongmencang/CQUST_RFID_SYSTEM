import threading
from datetime import datetime, timedelta
import time
from conflig import *
from dispose import mysql_cqust_rfid


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
    def __add_attendance_info(cls,sno,course_sections,cno,state,place):
        addtim=time.strftime('%Y-%m-%d %H:%M:%S', time.localtime())
        result= mysql_cqust_rfid.add_attendence_to_attendence_info(addtim,sno,course_sections,cno,state,place)
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
                print(wait_time)
                if wait_time > 0:
                    # 开一个线程等待打卡
                    threading.Timer(wait_time, mysql_cqust_rfid.auto_insert_not_attendance_student_info, args=(i+1,)).start()
                else:
                    return
                    # #为什么我会这么写呢，我也不知道 反正没打卡的就必须缺勤！就算系统关闭了，你也逃不掉，嘿嘿
                    mysql_cqust_rfid.auto_insert_not_attendance_student_info(i+1)
            # 计算距离午夜的时间
            next_midnight = (now + timedelta(days=1)).replace(hour=0, minute=0, second=0, microsecond=0)
            seconds_until_midnight = (next_midnight - now).total_seconds()
            # 新的一天 开启新的打卡任务！
            time.sleep(seconds_until_midnight)
