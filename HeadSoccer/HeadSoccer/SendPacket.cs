using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HeadSoccer
{
    public class SendPacket
    {
        private static UdpClient client = new UdpClient();
        public static string ipDest { get; set; }
        public static void SendPacketWithData(string azione, string dataIn)
        {
            string str = string.Empty;
            if (azione != string.Empty)
            {
                str = azione + dataIn;
                byte[] data = Encoding.ASCII.GetBytes(str);
                client.Send(data, data.Length, ipDest, 12345);
            }
        }
        public static void SendPacketWithoutData(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            client.Send(data, data.Length, ipDest, 12345);
        }
    }
}
