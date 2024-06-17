from conflig import FLAG_OK, FLAG_ERROR
from dispose import mysql_cqust_rfid


class SearchInformation:

    @classmethod
    def get_school_info(cls,argument):
        """
        获取学院信息
        :param argument:
        :return:
        """
        try:
            if not argument:#没有参数就是返回全部
                return {"flag":FLAG_OK,'data':mysql_cqust_rfid.get_all_school_name_from_school_info()}
            else:
                pass
        except:
            return {"flag":FLAG_ERROR}
        pass

    @classmethod
    def get_department_info(cls,argument):
        """
        系信息
        :param argument:
        :return:
        """
        try:
            if not argument:#没有参数就是返回全部
                return {"flag":FLAG_OK,'data':mysql_cqust_rfid.get_all_department_name_from_department_info()}
            else:
                return {"flag":FLAG_OK,"data":mysql_cqust_rfid.get_department_name_from_department_info_by_argument(argument)}
        except:
            return {"flag":FLAG_ERROR}
        pass


    @classmethod
    def get_subject_info(cls,argument):
        """
        专业信息
        :param argument:
        :return:
        """
        try:
            if not argument:#没有参数就是返回全部
                return {"flag":FLAG_OK,'data':mysql_cqust_rfid.get_all_subject_name_from_subject_info()}
            else:
                return {"flag":FLAG_OK,"data":mysql_cqust_rfid.get_subject_name_from_subject_info_by_argument(argument)}
        except:
            return {"flag":FLAG_ERROR}
        pass

    @classmethod
    def get_class_info(cls,argument):
        try:
            if not argument:#没有参数就是返回全部
                pass
            else:
                return {"flag":FLAG_OK,"data":mysql_cqust_rfid.get_class_name_from_class_info_by_argument(argument)}
        except:
            return {"flag":FLAG_ERROR}
        pass
    @classmethod
    def get_not_have_card_stu_info_by_class(cls,class_id):
        try:

            return {"flag":FLAG_OK,"data":mysql_cqust_rfid.get_not_have_card_student_by_class_id(class_id)}
        except:
            return {"flag":FLAG_ERROR}
        pass