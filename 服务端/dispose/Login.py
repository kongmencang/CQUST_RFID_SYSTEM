import threading

from dispose import *
class Login(object):

    @classmethod
    def __del_error_num(cls,user_id):
        del cls.__error_num_dic[user_id]

    #错误次数
    __error_num_dic={}
    @classmethod
    def login(cls, user_id, user_pwd):
        dic={}
        is_user_exist = mysql_cqust_rfid.get_is_user_exist_by_user_info(user_id=user_id)
        user_state=mysql_cqust_rfid.get_user_state(user_id=user_id)
        #用户不存在
        if not is_user_exist:
            dic["flag"]=FLAG_USER_NOT_EXIST
        elif user_state =="0":
            print("封禁中用户 {} 正在尝试登录".format(user_id))
            dic["flag"]=FLAG_LOGIN_ERR_MAX
        else:
            #账号密码错误
            is_login_success = mysql_cqust_rfid.get_user_id_and_user_pwd_is_matching(user_id=user_id, user_pwd=user_pwd)
            if not is_login_success:#登录失败
                dic["flag"]=FLAG_LOGIN_ERR
                if user_id not in cls.__error_num_dic:
                    cls.__error_num_dic[user_id]=1
                else:
                    cls.__error_num_dic[user_id]+=1
                print("用户：{} 登录失败 {}次".format(user_id, cls.__error_num_dic[user_id] ))
                ##限制用户一分钟内错误次数
                if cls.__error_num_dic[user_id]==1:
                    pass
                    #threading.Timer(30,lambda:cls.__del_error_num(user_id)).start()
                if cls.__error_num_dic[user_id]==3:
                    print("封禁用户：{} ".format(user_id))
                    mysql_cqust_rfid.set_user_state(user_id=user_id,state=USER_STATE_PENDING)
                    threading.Timer(30, lambda:(mysql_cqust_rfid.set_user_state(user_id=user_id,state=USER_STATE_NORMAL), print("解封用户：{} ".format(user_id)) )).start()
            else:
                user_name=mysql_cqust_rfid.get_user_name_by_user_id(user_id=user_id)
                user_power=mysql_cqust_rfid.get_user_power_by_user_id(user_id=user_id)
                dic["flag"]=FLAG_OK
                dic["data"]={}
                dic["data"]["user_name"]=user_name
                dic["data"]["user_power"]=user_power
                #获取用户所属学院
                dic["data"]["user_school_id"]=mysql_cqust_rfid.get_user_school_id_by_user_id(user_id)
                print("用户: {} 登录成功".format(user_id))
        return dic


#print(Login.login(user_id="2023520868", user_pwd="123"))
