from flask import Flask, request, jsonify
from flask_cors import CORS

from dispose.Login import Login

app = Flask(__name__)
CORS(app, resources={r"/*": {"origins": "*"}})  # 允许所有来源的请求


@app.route('/login', methods=['POST'])
def login_temp():
    if request.method == 'POST':
        user_id = request.json.get("user_id","")
        user_pwd = request.json.get("user_pwd","")
        result=Login.login(user_id, user_pwd)
        return jsonify(result), 200



if __name__ == '__main__':
    app.run(port=6666,debug=True,host='0.0.0.0')