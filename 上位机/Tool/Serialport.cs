using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CqustRfidSystem.Tool
{
    internal class Serialport
    {

        public static int DataBits = 8;
        public static int ReceivedBytesThreshold = 1;




        public static void open_usrt(SerialPort serialPort)
        {
            if (serialPort.IsOpen)
            {
                return;
            }
            try
            {
                serialPort.DataBits = DataBits;
                serialPort.ReceivedBytesThreshold = ReceivedBytesThreshold;
                serialPort.Open();

            }
            catch
            {
            }
        }

        public static void close_usrt(SerialPort serialPort)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public static void send_string_to_byte_data(SerialPort serialport, string str) {

            open_usrt(serialport);
            byte[] messageBytes = Encoding.ASCII.GetBytes(str);
   
            serialport.Write(messageBytes, 0, messageBytes.Length);

        }

    }
}
