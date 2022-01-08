using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace HeadSoccer
{
    class ComunicazionePlayer
    {
        string datiRicevuti = string.Empty;
        string nomeAvversario = string.Empty;
        SelectPlayer sp = new SelectPlayer();
        Thread ricezione;
        Comunicazione com;
        public string mioNome { get; set; }
        public string ipDest { get; set; }

        public ComunicazionePlayer(Comunicazione c)
        {
            com = c;
        }

        public void SendPacketWithData(string azione, string dataIn)
        {
            UdpClient client = new UdpClient();
            string str = string.Empty;
            if (azione != string.Empty)
            {
                str = azione + dataIn;
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
                byte[] bytes = receive.Receive(ref riceveEP);
                datiRicevuti = Encoding.ASCII.GetString(bytes);
                controlloMessaggi();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                MessageBox.Show("Errore di ricezione", "Errore di ricezione", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void controlloMessaggi()
        {
            string[] vs = datiRicevuti.Split(';');
            nomeAvversario = vs[1];

            MessageBox.Show(nomeAvversario);
            if (!vs[0].Equals(""))
            {
                if (vs[0].Equals("c"))
                {
                    if (MessageBox.Show(nomeAvversario + " ti ha inviato una richiesta di gioco", "Richiesta di gioco", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            InputDialog inputDialog = new InputDialog("Inserisci il tuo nome:", "");
                            if (inputDialog.ShowDialog() == true)
                            {
                                SendPacketWithData("y;", inputDialog.Answer);
                            }
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Connessione con: " + nomeAvversario + " rifiutata.", "Connessione rifiutata", MessageBoxButton.OK, MessageBoxImage.Information);
                        SendPacketWithoutData("n;");
                    }
                }
                else if (vs[0].Equals("y") && !vs[1].Equals(""))
                {
                    if (MessageBox.Show("Vuoi connetterti davvero con: " + nomeAvversario + "?", "Conferma connessione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SendPacketWithoutData("y;");
                        MessageBox.Show("Connessione con: " + nomeAvversario + " effettuata.", "Connessione effettuata", MessageBoxButton.OK, MessageBoxImage.Information);
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            sp.Show();
                            com.Close();
                        }));
                    }
                    else
                    {
                        SendPacketWithoutData("n;");
                    }
                }
                else if (vs[0].Equals("y"))
                {
                    MessageBox.Show("Connessione con: " + nomeAvversario + " effettuata.", "Connessione effettuata", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        sp.Show();
                        com.Close();
                    }));
                }
                // movimento giocatore
                else if (vs[0].Equals("a"))
                {

                }
                else if (vs[0].Equals("d"))
                {

                }
                else if (vs[0].Equals("space"))
                {

                }
                else if (vs[0].Equals("l"))
                {

                }
                //movimento palla
                else if (vs[0].Equals("p"))
                {

                }
                // fase chiusura
                else if (vs[0].Equals("e"))
                {

                }
            }
        }

        public void StartThreadRicezione()
        {
            ricezione = new Thread(new ThreadStart(ThreadReceive));
            ricezione.Start();
        }
    }
}
