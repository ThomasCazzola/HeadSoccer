using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HeadSoccer
{
    class ComunicazionePlayer
    {
        Giocatore playerEnemy = new Giocatore();
        string datiRicevuti = string.Empty;
        string nomeAvversario = string.Empty;
        SelectPlayer sp = new SelectPlayer();
        Thread ricezione;
        Comunicazione com;
        UdpClient receive;
        IPEndPoint riceveEP;
        Condivisa cond;
        public string mioNome { get; set; }

        public ComunicazionePlayer(Comunicazione c)
        {
            com = c;
            
            riceveEP = new IPEndPoint(IPAddress.Any, 0);
            receive = new UdpClient(12346);
            cond = Condivisa.getInstance();
        }

        public void ThreadReceive()
        {
            try
            {
                while (true)
                {
                    byte[] bytes = receive.Receive(ref riceveEP);
                    datiRicevuti = Encoding.ASCII.GetString(bytes);
                    controlloMessaggi(riceveEP.Address.ToString());
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                MessageBox.Show("Errore di ricezione", "Errore di ricezione", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void controlloMessaggi(string ipAddress)
        {
            string[] vs = datiRicevuti.Split(';');
            nomeAvversario = vs[1];
            //Setto il nome dell'avversario
            playerEnemy.Nome = nomeAvversario;
            MessageBox.Show(datiRicevuti);
            if (!vs[0].Equals(""))
            {
                if (vs[0].Equals("c"))
                {
                    if (MessageBox.Show(nomeAvversario + " ti ha inviato una richiesta di gioco", "Richiesta di gioco", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SendPacket.ipDest = ipAddress;
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            InputDialog inputDialog = new InputDialog("Inserisci il tuo nome:", "");
                            if (inputDialog.ShowDialog() == true)
                            {
                                SendPacket.SendPacketWithData("y;", inputDialog.Answer);
                            }
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Connessione con: " + nomeAvversario + " rifiutata.", "Connessione rifiutata", MessageBoxButton.OK, MessageBoxImage.Information);
                        SendPacket.SendPacketWithoutData("n;");
                    }
                }
                else if (vs[0].Equals("y") && !vs[1].Equals(""))
                {
                    if (MessageBox.Show("Vuoi connetterti davvero con: " + nomeAvversario + "?", "Conferma connessione", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SendPacket.SendPacketWithoutData("y;");
                        MessageBox.Show("Connessione con: " + nomeAvversario + " effettuata, verrai reindirizzato alla selezione del personaggio.", "Connessione effettuata", MessageBoxButton.OK, MessageBoxImage.Information);
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            sp.Show();
                            com.Close();
                        }));
                    }
                    else
                    {
                        SendPacket.SendPacketWithoutData("n;");
                    }
                }
                else if (vs[0].Equals("y"))
                {
                    MessageBox.Show("Connessione con: " + nomeAvversario + " effettuata, verrai reindirizzato alla selezione del personaggio.", "Connessione effettuata", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        sp.Show();
                        com.Close();
                    }));
                }
                // selezione giocatore
                else if (vs[0].Equals("s"))
                {
                    playerEnemy = new Giocatore(nomeAvversario, new BitmapImage(new Uri(@"images/" + vs[1] + ".png", UriKind.Relative)), 800, 750, 10, playerEnemy.mossaSpeciale);
                    Condivisa.GetInstance(playerEnemy);
                }
                // movimento giocatore
                else if (vs[0].Equals("a"))
                {
                    //Va a sinistra
                    playerEnemy.posX--;
                }
                else if (vs[0].Equals("d"))
                {
                    //Va a destra
                    playerEnemy.posX++;
                }
                else if (vs[0].Equals("space"))
                {
                    //Salto
                    //Ho fatto dei while in modo tale da rendere più fluido il movimento altrimenti sarebbe uno scatto su e giu.
                    int i = 0;
                    for (i = 0; i < 10; i++)
                    {
                        playerEnemy.posY++;
                        Thread.Sleep(10);
                    }
                    for (int k=i; k > -1; k--)
                    {
                        playerEnemy.posY--;
                        Thread.Sleep(10);
                    }
                }
                else if (vs[0].Equals("l"))
                {
                    //Super mossa
                }
                //movimento palla
                else if (vs[0].Equals("p"))
                {
                    //Direzione palla
                }
                // fase chiusura
                else if (vs[0].Equals("e"))
                {
                    SendPacket window = new SendPacket();
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