import pymysql


class BaseMysql(object):
    def __init__(self, user, password, database, host):
        self.host = host
        self.user = user
        self.password = password
        self.database = database

    def base_connect(self):
        try:
            self.conn = pymysql.connect(
                host=self.host, user=self.user, password=self.password, database=self.database)
            return self.conn.cursor()
        except pymysql.Error as e:
            print("连接失败", e)
            return None

    def base_select_sql(self, sql,params=None):
        con = self.base_connect()
        if not con:
            return []

        try:
            con.execute(sql,params)
            rows = con.fetchall()
            readlist = []
            for row in rows:
                readlist.append(list(row))
            return readlist
        except pymysql.Error as e:
            print("执行查询语句失败:{}".format(sql), e)
            return []
        finally:
            if con:
                con.close()

    def base_control_sql(self, sql,params):
        con = self.base_connect()
        if not con:
            return False

        try:
            result = con.execute(sql,params)
            self.conn.commit()
            return result > 0
        except pymysql.Error as e:
            print("执行修改指令错误:{}".format(sql), e)
            return False
        finally:
            if con:
                con.close()



    def base_is_attribute_exist_by_table(self, table_name, attribute_name,attribute_value):
        """
        查询表中的某个字段是否存在某个值
        :param table_name:在哪个表查
        :param attribute_name: 查哪个字段名
        :param attribute_value: 字段值等于
        :return: 该值是否存在 存在返回true 不存在返回error
        """
        sql="select * from {0} where {1} = %s ".format(table_name, attribute_name)
        params = (attribute_value,)
        result = self.base_select_sql(sql,params)
        if result:
            return True
        else:
            return False

    def base_get_attribute_value_by_table_and_one_condition(self, table_name, attribute_name,condition_name,condition_value):
        """
        根据某个值修改某表的另一个值
        :param table_name:
        :param attribute_name:
        :param condition_name:
        :param condition_value:
        :return:
        """
        sql = "select {0} from {1} where {2} =%s".format(attribute_name,table_name,condition_name)
        params = (condition_value,)
        result = self.base_select_sql(sql,params)
        return result
    def base_update_attribute_value_by_table_and_one_condition(self, table_name, attribute_name,attribute_value,condition_value,condition_name):
        sql = "update {0} set {1} = %s where {2} = %s ".format(table_name,attribute_name,condition_name)
        params = (attribute_value,condition_value)
        return self.base_control_sql(sql=sql,params=params)

