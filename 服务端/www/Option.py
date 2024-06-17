from conflig import FLAG_ERROR
from dispose.SearchInformation import SearchInformation

class Option(object):
    @classmethod
    def get_info_option(cls, option, argument):
        actions = {
            "school_info": SearchInformation.get_school_info,
            "department_info": SearchInformation.get_department_info,
            "subject_info": SearchInformation.get_subject_info,
            "class_info":SearchInformation.get_class_info,
            "not_have_card_stu_info": SearchInformation.get_not_have_card_stu_info_by_class
        }
        # 根据 option 获取相应的函数
        action = actions.get(option, None)
        if action is not None:
            return action(argument)
        else:
            return {"flag": FLAG_ERROR}
