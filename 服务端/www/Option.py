from conflig import FLAG_ERROR
from dispose.SearchInformation import SearchInformation

class Option(object):
    @classmethod
    def get_info_option(cls, option, argument):

        print(option)
        actions = {
            "school_info": SearchInformation.get_school_info,
        }
        # 根据 option 获取相应的函数
        action = actions.get(option, None)
        if action is not None:
            print(action)
            return action(argument)
        else:
            return {"flag": FLAG_ERROR}
