using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace HeadSoccer
{
    class ComunicazionePlayer
    {
        string datiRicevuti = string.Empty;
        string nomeAvversario = string.Empty;
        public string mioNome { get; set; }
        public string ipDest { get; set; }
        public void SendPacketWithData(string azione, string dataIn)
        {
            UdpClient client = new UdpClient();
            string str = string.Empty;
            if (azione != null)
            {
                str = azione + ";" + dataIn;
                byte[] data = Encoding.ASCII.GetBytes(str);
                client.Send(data, data.Length, ipDest, 12345);
            }
        }
        private void SendPacketWithoutData(string str)
        {
            UdpClient client = new UdpClient();
            byte[] data = Encoding.ASCII.GetBytes(str);
            client.Send(data, data.Length, ipDest, 12345);
        }

        public void ThreadReceive()
        {
            try
            {
                UdpClient receive = new UdpClient(12346);
                IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
                // while fino alla fine del punteggio o del tempo
                byte[] bytes = receive.Receive(ref riceveEP);
                datiRicevuti = Encoding.ASCII.GetString(bytes);
                controlloMessaggi();
            }
            catch (Exception e)
            {
                //errore
                MessageBox.Show("Errore di ricezione", "Errore di ricezione", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void controlloMessaggi()
        {
            string[] vs = datiRicevuti.Split(';');
            nomeAvversario = vs[1];
            if (!vs[0].Equals(" "))
            {
                if (vs[0].Equals("c"))
                {
                    if (MessageBox.Show(nomeAvversario + " ti ha inviato una richiesta di gioco", "Richiesta di gioco", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SendPacketWithData("y;", mioNome);
                    }
                    else
                    {
                        MessageBox.Show("Connessione con: " + nomeAvversario + " rifiutata.", "Connessione rifiutata", MessageBoxButton.OK, MessageBoxImage.Information);
                        SendPacketWithoutData("n;");
                    }
                }
                else if (vs[0].Equals("y") && !vs[1].Equals(" "))
                {
                    if (MessageBox.Show("Vuoi connetterti davvero con: " + nomeAvversario + "?", "Conferma connessione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SendPacketWithoutData("y;");
                        MessageBox.Show("Connessione con: " + nomeAvversario + " effettuata.", "Connessione effettuata", MessageBoxButton.OK, MessageBoxImage.Information);
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            SelectPlayer sp = new SelectPlayer();
                            sp.Show();
                        }));
                    }else
                    {
                        SendPacketWithoutData("n;");
                    }
                }
                else if (vs[0].Equals("y"))
                {
                    MessageBox.Show("Connessione con: " + nomeAvversario + " effettuata.", "Connessione effettuata", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectPlayer sp = new SelectPlayer();
                        sp.Show();
                    }));
                }else if (vs[0].Equals("n"))
                {
                    MessageBox.Show("Connessione con: " + nomeAvversario + " bloccata.", "Connessione rifiutata", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
