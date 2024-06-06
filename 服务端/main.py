from conflig import MYSQL_USERNAME, MYSQL_PASSWORD, MYSQL_HOST, MYSQL_DATABASE
from mysql.CqustCardSystemMysql import CqustCardSystemMysql

mysql = CqustCardSystemMysql(MYSQL_USERNAME,MYSQL_PASSWORD,MYSQL_DATABASE,MYSQL_HOST)

#cqust_cart_system_mysql.is_card_exeit(sno="2023520868" ,card_id= "429E40E7")
sno="2023520868"
card_id= "429E40E7"

ans=mysql.get_sno_by_card_id_from_rfid_info(card_id)
print(ans)

ans=mysql.get_card_id_by_sno_from_rfid_info(sno)
print(ans)