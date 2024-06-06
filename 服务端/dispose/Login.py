import threading

from dispose import *
class Login(object):
    #错误次数
    __error_num=0
    @classmethod
    def login(cls, user_id, user_pwd):
        dic={}
        is_user_exist = mysql.get_is_user_exist_by_user_info(user_id=user_id)
        user_state=mysql.get_user_state(user_id=user_id)
        #用户不存在
        if not is_user_exist:
            dic["flag"]=FLAG_USER_NOT_EXIST
        elif user_state =="0":
            print("封禁中用户 {} 正在尝试登录".format(user_id))
            dic["flag"]=FLAG_LOGIN_ERR_MAX
        else:
            #账号密码错误
            is_login_success = mysql.get_user_id_and_user_pwd_is_matching(user_id=user_id, user_pwd=user_pwd)
            if not is_login_success:
                dic["flag"]=FLAG_LOGIN_ERR
                cls.__error_num += 1
                print("用户：{} 登录失败 {}次".format(user_id, cls.__error_num ))
                if cls.__error_num==3:
                    print("封禁用户：{} ".format(user_id))
                    mysql.set_user_state(user_id=user_id,state=USER_STATE_PENDING)
                    cls.__error_num = 0
                    threading.Timer(5, lambda:(mysql.set_user_state(user_id=user_id,state=USER_STATE_NORMAL), print("解封用户：{} ".format(user_id)) )).start()

            else:
                dic["flag"]=FLAG_OK
                print("用户: {} 登录成功".format(user_id))

        return dic


#print(Login.login(user_id="2023520868", user_pwd="123"))
