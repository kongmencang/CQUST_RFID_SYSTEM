from flask import Flask,request,jsonify
from flask_cors import CORS

from dispose.Attendance import Attendance
from dispose.Login import Login
from dispose.RfidCard import RfidCard

app = Flask(__name__)
CORS(app, resources={r"/*": {"origins": "*"}})  # 允许所有来源的请求



@app.route('/login', methods=['POST'])
def login():
    if request.method == 'POST':
        user_id = request.json.get("user_id","")
        user_pwd = request.json.get("user_pwd","")
        result=Login.login(user_id, user_pwd)
        return jsonify(result), 200


@app.route('/add_card', methods=['POST'])
def add_cards():
    if request.method == 'POST':
        sno = request.json.get("sno","")
        card_id = request.json.get("card_id","")
        result = RfidCard.add_card(sno=sno, card_id=card_id)
        return jsonify(result),200

@app.route('/add_attendance', methods=['POST'])
def add_attendance():
    if request.method == 'POST':
        sno = request.json.get("sno","")
        time_str = request.json.get("time_str","")
        place = request.json.get("place","")
        result = Attendance.attendance(sno,time_str,place)
        return jsonify(result),200

if __name__ == '__main__':
    app.run(port=6666,debug=True,host='0.0.0.0')