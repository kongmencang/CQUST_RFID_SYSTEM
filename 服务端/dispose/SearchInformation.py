from conflig import FLAG_OK, FLAG_ERROR
from dispose import mysql_cqust_rfid


class SearchInformation:

    @classmethod
    def get_school_info(cls,argument):
        try:
            if not argument:#没有参数就是返回全部
                return {"flag":FLAG_OK,'data':mysql_cqust_rfid.get_all_school_name_from_school_info()}
            else:
                pass
        except:

            return {"flag":FLAG_ERROR}
        pass
    pass
