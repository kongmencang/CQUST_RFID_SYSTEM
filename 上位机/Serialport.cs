using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CqustRfidSystem
{
    internal class Serialport
    {
        public static string PortName="COM10";
        public static int BaudRate = 4800;
        public static int DataBits = 8;
        public static int ReceivedBytesThreshold = 1;
     


        public static void open_usrt(SerialPort serialport)
        {
            if (serialport.IsOpen)
            {
                return;
            }
            try
            {
                serialport.PortName = PortName;
                serialport.BaudRate = BaudRate;
                serialport.DataBits = DataBits;
                serialport.ReceivedBytesThreshold = ReceivedBytesThreshold;
                serialport.Open();
            }
            catch
            {
                MessageBox.Show("打开失败");

            }
        }

        public static void close_usrt(SerialPort serialport)
        {
            if (serialport.IsOpen)
            {
                serialport.Close();
            }

        }

        public static void send_string_to_byte_data(SerialPort serialport,string str ) {
            open_usrt(serialport);
            byte[] data = Encoding.Default.GetBytes(str);
            try
            {
                serialport.Write(data, 0, data.Length);
            }
            catch { }
     

        }




    }




}