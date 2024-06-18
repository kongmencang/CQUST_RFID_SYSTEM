from conflig import *
from dispose import mysql_cqust_rfid


class RfidCard:
    @classmethod
    def add_card(cls,card_id,sno):
        """
        添加新卡
        :param card_id:
        :param sno:
        :return:
        """
        dic={}
        dic["data"] = {}
        stu_name = mysql_cqust_rfid.get_stu_name_by_sno(sno=sno)
        if not stu_name:
            dic["flag"] = FLAG_NOT_STUDENT
            return dic
        is_card_exist = mysql_cqust_rfid.is_card_exist(card_id=card_id)
        is_sno_exist = mysql_cqust_rfid.is_sno_exist(sno=sno)


        #这张卡片已经有人，且卡片归属者不属于待发卡学生
        if is_card_exist:
            sno=mysql_cqust_rfid.get_sno_by_card_id_from_rfid_info(card_id=card_id)
            stu_name = mysql_cqust_rfid.get_stu_name_by_sno(sno=sno)
            dic["flag"]=FLAG_CARD_IS_USING
            dic["data"]["name"] = stu_name
        #这个学生已经有卡了
        elif is_sno_exist:
            this_stu_card_id = mysql_cqust_rfid.get_card_id_by_sno_from_rfid_info(sno=sno)
            dic["flag"]=FLAG_USER_HAVE_CARD
            dic["data"]["name"] =stu_name
            dic["data"]["card_id"] =this_stu_card_id

        else:
            result=mysql_cqust_rfid.add_card_to_rfid_info(card_id=card_id,sno=sno)
            if result:
                dic["flag"]=FLAG_OK
            else:
                dic["flag"]=FLAG_ADD_CARD_NOT_SUCCESS
            dic["data"]["name"] =stu_name

        return dic

