from flask import Flask,request,jsonify
from flask_cors import CORS

from conflig import FLAG_ERROR
from dispose.Attendance import Attendance
from dispose.Login import Login
from dispose.RfidCard import RfidCard
from www.Option import Option

app = Flask(__name__)
CORS(app, resources={r"/*": {"origins": "*"}})  # 允许所有来源的请求


run_flag = False


@app.route('/login', methods=['POST'])
def login():
    if request.method == 'POST':
        user_id = request.json.get("user_id")
        user_pwd = request.json.get("user_pwd")
        if not user_id or not user_pwd:
            return jsonify({"flag": FLAG_ERROR}), 200

        result=Login.login(user_id, user_pwd)
        return jsonify(result), 200




@app.route('/add_card', methods=['POST'])
def add_cards():
    if request.method == 'POST':
        sno = request.json.get("sno")
        card_id = request.json.get("card_id")
        if not card_id or not sno:
            return jsonify({"flag": FLAG_ERROR}), 200
        result = RfidCard.add_card(sno=sno, card_id=card_id)

        return jsonify(result),200
@app.route('/add_attendance', methods=['POST'])
def add_attendance():
    if request.method == 'POST':
        sno = request.json.get("sno")
        time_str = request.json.get("time_str")
        place=request.json.get("place")
        if not time_str or not sno or not place:
            return jsonify({"flag": FLAG_ERROR}), 200
        result = Attendance.attendance(sno=sno, place=place, time_str=time_str)

        return jsonify(result),200


@app.route('/get_info', methods=['POST'])
def get_info():
    if request.method == 'POST':
        how_get = request.json.get("info_name")#获取什么信息
        argument =request.json.get("info_argument")#查询参数
        if not how_get:
            return jsonify({"flag": FLAG_ERROR}), 200
        return jsonify(Option.get_info_option(how_get,argument)),200


def run():
    global run_flag
    if run_flag==False:
        app.run(port=6666, debug=True, host='0.0.0.0')
        run_flag=True;
if __name__ == '__main__':
    pass