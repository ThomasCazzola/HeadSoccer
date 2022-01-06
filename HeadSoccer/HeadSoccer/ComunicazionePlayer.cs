using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HeadSoccer
{
    class ComunicazionePlayer
    {
        private UdpClient client;
        public void Send(string dataIn, string ipAddress)
        {
            client = new UdpClient();

            byte[] data = Encoding.ASCII.GetBytes(dataIn);

            client.Send(data, data.Length, ipAddress, 12345);
        }

        public string Receive()
        {
            IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);

            byte[] dataReceived = client.Receive(ref riceveEP);

            string risposta = Encoding.ASCII.GetString(dataReceived);

            return risposta;
        }
    }
}
