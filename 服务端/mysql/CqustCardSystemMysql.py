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


    def get_is_user_exist_by_user_info(self,user_id):
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
        return self.base_get_attribute_value_by_table_and_one_condition(table_name=MYSQL_USER_INFO_TABLE,attribute_name="state",condition_name="user_id",condition_value=user_id)[0][0]