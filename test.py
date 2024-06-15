import serial

# 配置串口
ser = serial.Serial('COM18', 4800, timeout=1)

def send_data(data):
    ser.write(data)

def receive_data():
    return ser.read(16)

def main():
    try:
        # 发送数据示例
        data_to_send = b'w2023520868#'  # 示例数据，开头为'w'，后面是10个数字，最后是'#'
        send_data(data_to_send)
        print(f"Sent: {data_to_send}")

        # 接收响应
        response = receive_data()
        print(f"Received: {response}")

        # 解析响应（如果需要）
        if len(response) == 16:
            parsed_response = [hex(b) for b in response]
            print(f"Parsed Response: {parsed_response}")
        else:
            print("Invalid response length")

    except Exception as e:
        print(f"An error occurred: {e}")

    finally:
        ser.close()

if __name__ == "__main__":
    main()
