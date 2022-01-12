using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeadSoccer
{
    /// <summary>
    /// Interaction logic for SelectPlayer.xaml
    /// </summary>
    public partial class SelectPlayer : Window
    {

        int i = 1;
        string nomePlayerSelezionato { get; set; }
        public SelectPlayer()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            i--;

            if(i < 1)
            {
                i = 5;
            }

            players.Source = new BitmapImage(new Uri(@"images/" + i + ".png", UriKind.Relative));
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            i++;

            if (i > 5)
            {
                i = 1;
            }

            players.Source = new BitmapImage(new Uri(@"images/player" + i + ".png", UriKind.Relative));
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow(i);
            switch (i)
            {
                case 1:
                    nomePlayerSelezionato = "player1";
                    break;
                case 2:
                    nomePlayerSelezionato = "player2";
                    break;
                case 3:
                    nomePlayerSelezionato = "player3";
                    break;
                case 4:
                    nomePlayerSelezionato = "player4";
                    break;
                case 5:
                    nomePlayerSelezionato = "player5";
                    break;
                default:
                    break;
            }
            SendPacket.SendPacketWithData("s;", nomePlayerSelezionato);
            m.Show();
            Close();
        }

    }
}
