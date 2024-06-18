from datetime import datetime

from conflig import *
from mysql.BaseMysql import BaseMysql


"""

            dic["code"]="ok"
            if is_card_exist and is_sno_exist:
                dic["result"]="all exist"
            elif is_card_exist:
                dic["result"]="card_id exist"
            elif is_sno_exist:
                dic["result"]="sno exist"
        except Exception as e:
            print("错误来自于 is_card_and_sno_exist " +e)
            dic["code"]="error"
"""

class CqustCardSystemMysql(BaseMysql):

    """
    mysql操作类

    """

    """
    以下部分为RFID卡片相关
    """
    def is_sno_exist(self,sno):
        """
        学生是否已经分到卡了
        :param sno:
        :return:
        """
        try:
            is_sno_exist = self.base_is_attribute_exist_by_table(table_name=MYSQL_RFID_INFO_TABLE,attribute_name="sno",attribute_value=sno)
            if is_sno_exist:
                return  True
            else:
                return False
        except Exception as e:
            print("发生错误于：is_sno_exist，参数{0} ".format(sno)+e)
            return False

    def is_card_exist(self,card_id):
        """
        rfid卡是否已经存在了
        :param card_id:
        :return:
        """
        try:
            is_card_exist = self.base_is_attribute_exist_by_table(table_name=MYSQL_RFID_INFO_TABLE,attribute_name="card_id",attribute_value=card_id)
            if is_card_exist:
                return True
            else:
                return False
        except Exception as e:
            print("错误来自于 is_card_exist,参数{0} ".format(card_id) +e)
            return  False



    def get_sno_by_card_id_from_rfid_info(self,card_id):
        """
        根据卡号获取学号
        :param card_id:
        :return:
        """
        try:
            result= self.base_get_attribute_value_by_table_and_one_condition(table_name=MYSQL_RFID_INFO_TABLE,attribute_name="sno",condition_name="card_id",condition_value=card_id)
            return result[0][0]
        except Exception as e:
            print("错误来自于 get_sno_by_card_id_from_rfid_info，参数{} ".format(card_id) + e)

    def get_card_id_by_sno_from_rfid_info(self,sno):
        """
        根据学号获取卡号
        :param sno:
        :return:
        """
        try:
            result= self.base_get_attribute_value_by_table_and_one_condition(table_name=MYSQL_RFID_INFO_TABLE,attribute_name="card_id",condition_name="sno",condition_value=sno)
            return result[0][0]
        except Exception as e:
            print("错误来自于 get_sno_by_card_id_from_rfid_info，参数{} ".format(sno) + e)



    def add_card_to_rfid_info(self,sno,card_id):
        try:
            insert_data={"card_id":card_id,"sno":sno}
            result =self.base_insert_value_to_table(table_name=MYSQL_RFID_INFO_TABLE,insert_data=insert_data)
            return result
        except Exception as e:
            print("错误来自于 add_card_to_rfid_info， 参数{} {} ".format(sno,card_id)+e)

    """
    以下内容为用户相关
    """

    def get_is_user_exist_by_user_info(self,user_id):
        """
        用户是否存在
        :param user_id:
        :return:
        """
        try:
            result = self.base_is_attribute_exist_by_table(table_name=MYSQL_USER_INFO_TABLE,attribute_name="user_id",attribute_value=user_id)
            return result
        except Exception as e:
            print("错误来自于 get_is_user_exist_by_user_info,参数{0} ".format(user_id) +e)
            return  False


    def get_user_id_and_user_pwd_is_matching(self,user_id,user_pwd):
        """
        用户名是否和密码匹配
        :param user_id:
        :param user_pwd:
        :return:
        """
        sql = "select user_id,user_pwd from {} where user_id= %s and user_pwd= %s".format(MYSQL_USER_INFO_TABLE)
        params = (user_id,user_pwd)
        try:
            result = self.base_select_sql(sql=sql,params=params)
            if result:
                return True
            else:
                return False
        except Exception as e:
            print("错误来自于 get_is_user_exist_by_user_info,user_id:{0},user_pwd{}  ".format(user_id,user_pwd) + e)
            return False

    def set_user_state(self,user_id,state):
        """
        修改用户状态
        :param user_id:
        :param state: 1 正常 0封禁
        :return:
        """
        return  self.base_update_attribute_value_by_table_and_one_condition(table_name=MYSQL_USER_INFO_TABLE,attribute_name="state",attribute_value=state,condition_value=user_id,condition_name="user_id")

    def get_user_state(self,user_id):
        """
        返回用户状态
        :param user_id:
        :return:
        """
        result = self.base_get_attribute_value_by_table_and_one_condition(table_name=MYSQL_USER_INFO_TABLE,attribute_name="state",condition_name="user_id",condition_value=user_id)
        if result:
            return result[0][0]
        else:
            return None

    def get_user_name_by_user_id(self,user_id):
        """
        查找用户姓名
        :param user_id:
        :return:
        """
        result = self.base_get_attribute_value_by_table_and_one_condition(table_name=MYSQL_TEACHER_INFO_TABLE,attribute_name="teacher_name",condition_name="teacher_id",condition_value=user_id)
        if result:
            return result[0][0]
        else:
            return None
    def get_user_power_by_user_id(self,user_id):
        """
        查找用户权限
        :param user_id:
        :return:
        """
        result = self.base_get_attribute_value_by_table_and_one_condition(table_name=MYSQL_TEACHER_INFO_TABLE,attribute_name="teacher_power",condition_name="teacher_id",condition_value=user_id)
        if result:
            return result[0][0]
        else:
            return None
    """
    以下内容跟学生信息相关
    """
    def get_stu_name_by_sno(self,sno):
        """
        根据学号获取学生姓名
        :param sno:
        :return:
        """
        result = self.base_get_attribute_value_by_table_and_one_condition(attribute_name="name",table_name=MYSQL_STU_INFO_TABLE,condition_name="sno",condition_value=sno)
        if result:
            return  result[0][0]
        else:
            return None

    def get_stu_scheduling_id_by_sno(self,sno):
        """
        获取学生的选课id
        :param sno:学号
        :return:[开课编号列表]
        """
        # 选课id
        sql=f"""
        select scheduling_id from {MYSQL_STU_COURSE_SELECTION_INFO_TABLE} where sno = %s
        """
        param=(sno,)
        result=self.base_select_sql(sql,param)
        if result:
            ans=[]
            for i in result:
                ans.append(i[0])
            return ans
        return None

    """
    课程相关
    """
    def get_techer_id_and_course_id_by_time_and_scheduling_id(self,course_section,scheduling_id,place):
        """
        根据排课节次和排课编号获取对应那节课的教师id和课程id
        :param course_section: 排课节次
        :param scheduling_id:课程id
        :return:{教师id："",课程id:""}
        """
        weekday =  datetime.now().weekday() + 1
        params = (TERM_TIME,scheduling_id, course_section,place)
        sql= f"""
        select course_id ,teacher_id from {MYSQL_SCHEDULING_INFO_TABLE} 
        where term_time = %s and weekday = {weekday} and scheduling_id=%s
        and course_section = %s and state = '1' and place=%s
        """
        result = self.base_select_sql(sql,params)
        if result:
            return {'course_id':result[0][0],'teacher_id':result[0][1]}
        return None

    """
    考勤相关
    """
    def add_attendence_to_attendence_info(self,addtime,sno,course_sections,cno,state,place):
        """
        添加考勤信息
        :param addtime:
        :param sno:
        :param course_sections:
        :param cno:
        :param state:
        :param place:
        :return:
        """
        try:
            insert_data={"addtime":addtime,"sno":sno,'course_sections':course_sections,'cno':cno,'state':state,'place':place}
            result =self.base_insert_value_to_table(table_name=MYSQL_ATTENDENCE_INFO_TABLE,insert_data=insert_data)
            return result
        except Exception as e:
            print("错误来自于 add_attendence_to_attendence_info， 参数{} {} ".format(addtime,sno,str(course_sections),cno,str(state),place)+e)
    def get_stu_is_attendence_info_by_time(self,sno,starttime,endtime):
        sql=f"""
            SELECT *
            FROM {MYSQL_ATTENDENCE_INFO_TABLE}
            WHERE STR_TO_DATE(addtime, '%Y-%m-%d %H:%i:%s') BETWEEN '{starttime}' AND '{endtime}' AND sno = '{sno}';
        """
        params=None
        result  =self.base_select_sql(sql,params=params)

        if result:
            return result
        else:
            return None

    """
    下面是信息综合查询相关
    """
    def get_all_school_name_from_school_info(self):
        """
        查询所有的学院名
        :return: 字典列表[{school_id:school_name},{school_id:school_name}]
        """
        result=self.base_get_a_table_all_data(table_name=MYSQL_SCHOOL_INFO_TABLE)
        ans =[]
        if result:
            for i in result:
                school_id=i[0]
                school_name=i[1]
                ans.append({"school_id":school_id,"school_name":school_name})
            return ans
        else:
            return None


    def get_all_department_name_from_department_info(self):
        """
        查询所有的系名
        :return: 字典列表[{"department_id": department_id, "department_name": department_name}]
        """
        result = self.base_get_a_table_all_data(table_name=MYSQL_DEPARTMENT_INFO_TABLE  )
        ans = []
        if result:
            for i in result:
                department_id = i[0]
                department_name = i[1]
                ans.append({"department_id": department_id, "department_name": department_name})
            return ans
        else:
            return None
    def get_department_name_from_department_info_by_argument(self,argument):
        """
        根据参数字典进行查询
        :param argument:  {"school_id": school_id , "department_id": department_id}
        :return 字典列表[{"department_id": department_id, "department_name": department_name}
        """
        sql = f"select department_id, department_name from {MYSQL_DEPARTMENT_INFO_TABLE} where "
        #拼接查询语句
        for i in argument.keys():
            sql += i + f" = %({i})s "
        result =self.base_select_sql(sql,argument)
        ans = []
        if result:
            for i in result:
                department_id = i[0]
                department_name = i[1]
                ans.append({"department_id": department_id, "department_name": department_name})
            return ans
        else:
            return None




    def get_all_subject_name_from_subject_info(self):
        """
        查询所有的专业名
        :return: 字典列表
        """
        result = self.base_get_a_table_all_data(table_name=MYSQL_SUBJECT_INFO_TABLE)
        ans = []
        if result:
            for i in result:
                subject_id = i[0]
                subject_name = i[1]
                ans.append({"subject_id": subject_id, "subject_name": subject_name})
            return ans
        else:
            return None
    def get_subject_name_from_subject_info_by_argument(self,argument):
        """
        根据参数字典进行查询
        :param argument:{‘argument_name’：‘argument_value’}
        :return 字典列表
        """
        sql = f"select subject_id, subject_name from {MYSQL_SUBJECT_INFO_TABLE} where "
        #拼接查询语句
        for i in argument.keys():
            sql += i + f" = %({i})s "
        result =self.base_select_sql(sql,argument)
        ans = []
        if result:
            for i in result:
                subject_id = i[0]
                subject_name = i[1]
                ans.append({"subject_id": subject_id, "subject_name": subject_name})
            return ans
        else:
            return None
    def get_class_name_from_class_info_by_argument(self,argument):
        """
        根据参数字典进行查询
        :param argument:{‘argument_name’：‘argument_value’}
        :return 字典列表
        """
        sql = f"select class_id, class_name from {MYSQL_CLASS_INFO_TABLE} where "
        #拼接查询语句
        for i in argument.keys():
            sql += i + f" = %({i})s "
        result =self.base_select_sql(sql,argument)
        ans = []
        if result:
            for i in result:
                class_id = i[0]
                class_name = i[1]
                ans.append({"class_id": class_id, "class_name": class_name})
            return ans
        else:
            return None

    def get_not_have_card_student_by_class_id(self,argument):
        """
        获取没有卡的学生的id，根据班级编号
        :param class_id:
        :return:
        """
        sql=f"""
        SELECT si.sno  ,si.name
        FROM {MYSQL_STU_INFO_TABLE} si  
        LEFT JOIN rfid_info ri ON si.sno = ri.sno  
        WHERE ri.sno IS NULL and si.class_id =%(class_id)s ;
        """

        result = self.base_select_sql(sql,argument)
        ans = []
        if result:
            for i in result:
                stu_sno = i[0]
                stu_name= i[1]
                ans.append({"student_id": stu_sno, "student_name": stu_name})
            return ans
        else:
            return None

if __name__ == '__main__':
    # a={"school_id":"0100000000"}
    mysql_cqust_rfid = CqustCardSystemMysql(MYSQL_USERNAME, MYSQL_PASSWORD, MYSQL_DATABASE, MYSQL_HOST)

    print(mysql_cqust_rfid.get_not_have_card_student_by_class_id({"class_id":"0101010002"}))