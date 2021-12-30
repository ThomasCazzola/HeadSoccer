using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace HeadSoccer
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        //bool gameOver = false;
        bool goDx, goSx, intercPalla1; //intercPalla2;
        int gravity = 8, ballGravity = 5;
        Rect playerHitBox, ballHitBox, groundHitBox;
        Random r = new Random();
        int dirPalla = 0;

        public MainWindow(int index)
        {
            InitializeComponent();
            gameTimer.Tick += gameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(1000 / 120);
            StartGame();
            dirPalla = GeneraDirPallaRandom();
            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.ActualWidth, Player.ActualHeight);
            ballHitBox = new Rect(Canvas.GetLeft(Palla), Canvas.GetTop(Palla), Palla.ActualWidth, Palla.ActualHeight);
            groundHitBox = new Rect(Canvas.GetLeft(Ground), Canvas.GetTop(Ground), Ground.ActualWidth, Ground.ActualHeight);
            ControllaGiocatoreSelezionato(index);
        }

        private void gameEngine(object sender, EventArgs e)
        {
            playerHitBox.X = Canvas.GetLeft(Player); playerHitBox.Y = Canvas.GetTop(Player); playerHitBox.Width = Player.ActualWidth; playerHitBox.Height = Player.ActualHeight;
            ballHitBox.X = Canvas.GetLeft(Palla); ballHitBox.Y = Canvas.GetTop(Palla); ballHitBox.Width = Palla.ActualWidth; ballHitBox.Height = Palla.ActualHeight;
            groundHitBox.X = Canvas.GetLeft(Ground); groundHitBox.Y = Canvas.GetTop(Ground); groundHitBox.Width = Ground.ActualWidth; groundHitBox.Height = Ground.ActualHeight;
            Canvas.SetTop(Player, Canvas.GetTop(Player) + gravity);
            if (goDx)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 10);
            }
            if (goSx)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - 5);
            }
            if (!intercPalla1)
            {
                if (dirPalla == 1)
                {
                    Canvas.SetLeft(Palla, Canvas.GetLeft(Palla) - ballGravity);
                    Canvas.SetTop(Palla, Canvas.GetTop(Palla) + ballGravity);
                }
                else if (dirPalla == 2)
                {
                    Canvas.SetLeft(Palla, Canvas.GetLeft(Palla) + ballGravity);
                    Canvas.SetTop(Palla, Canvas.GetTop(Palla) + ballGravity);
                }
            }
            else if (intercPalla1)
            {
                Canvas.SetLeft(Palla, Canvas.GetLeft(Palla) + ballGravity);
                Canvas.SetTop(Palla, Canvas.GetTop(Palla) - ballGravity);
            }

            Intersezioni();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    gravity = 8;
                    break;
                case Key.D:
                    goDx = true;
                    break;
                case Key.A:
                    goSx = true;
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    gravity = 8;
                    break;
                case Key.D:
                    goDx = false;
                    break;
                case Key.A:
                    goSx = false;
                    break;
            }
        }

        private void StartGame()
        {
            gameTimer.Start();
            myCanvas.Focus();
            //gameOver = false;
            Canvas.SetTop(Player, 600);
            Canvas.SetLeft(Player, 200);
        }

        private void EndGame()
        {
            //gameOver = true;
        }

        private int GeneraDirPallaRandom()
        {
            dirPalla = r.Next(2) + 1;
            return dirPalla;
        }

        private void Intersezioni()
        {
            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                Canvas.SetTop(Player, Canvas.GetTop(Ground) - Player.ActualHeight);
            }
            if (ballHitBox.IntersectsWith(playerHitBox))
            {
                if (dirPalla == 1)
                {
                    intercPalla1 = true;
                    dirPalla = 2;
                }
            }
        }

        private void ControllaGiocatoreSelezionato(int indexPlayer)
        {
            switch (indexPlayer)
            {
                case 0:
                    return;
                case 1:
                    Player.Source = new BitmapImage(new Uri(@"images/player1.png", UriKind.Relative));
                    break;
                case 2:
                    Player.Source = new BitmapImage(new Uri(@"images/player2.png", UriKind.Relative));
                    break;
                case 3:
                    Player.Source = new BitmapImage(new Uri(@"images/player3.png", UriKind.Relative));
                    break;
                case 4:
                    Player.Source = new BitmapImage(new Uri(@"images/player4.png", UriKind.Relative));
                    break;
                case 5:
                    Player.Source = new BitmapImage(new Uri(@"images/player5.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }
    }
}
