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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace HeadSoccer
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        bool goDx, goSx;
        int gravity = 3;
        int idPlayer = 0;
        public MainWindow(int idGiocatore)
        {
            InitializeComponent();
            timer.Tick += new EventHandler(gameEngine);
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            idGiocatore = idPlayer;
            if (idPlayer == 1)
            {
                Player.Source = new BitmapImage(new Uri(@"HeadSoccer\\images\\player1.png"));
            }
            else if (idPlayer == 2)
            {
                Player.Source = new BitmapImage(new Uri(@"HeadSoccer\\images\\player2.png"));
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            if (Canvas.GetTop(Player) > 365)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) + gravity);
            }
            if (goDx)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 5);
            }
            if (goSx)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - 5);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                goDx = true;
            }
            if (e.Key == Key.A)
            {
                goSx = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                goDx = false;
            }
            if (e.Key == Key.A)
            {
                goSx = false;
            }
        }
    }
}
