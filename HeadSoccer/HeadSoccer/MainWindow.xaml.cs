using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick += gameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            StartGame();
            dirPalla = GeneraDirPallaRandom();
        }

        private void gameEngine(object sender, EventArgs e)
        {
            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.ActualWidth, Player.ActualHeight);
            ballHitBox = new Rect(Canvas.GetLeft(Palla), Canvas.GetTop(Palla), Palla.ActualWidth, Palla.ActualHeight);
            groundHitBox = new Rect(Canvas.GetLeft(Ground), Canvas.GetTop(Ground), Ground.ActualWidth, Ground.ActualHeight);
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
            }else if (intercPalla1)
            {
                Canvas.SetLeft(Palla, Canvas.GetLeft(Palla) + ballGravity);
                Canvas.SetTop(Palla, Canvas.GetTop(Palla) - ballGravity);
            }
            //else if (intercPalla2){
            //    Canvas.SetLeft(Palla, Canvas.GetLeft(Palla) - ballGravity);
            //    Canvas.SetTop(Palla, Canvas.GetTop(Palla) - ballGravity);
            //}

            Intersezioni();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                gravity = 8;
            }
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
            if (e.Key == Key.Space)
            {
                gravity = -8;
            }
            if (e.Key == Key.D)
            {
                goDx = false;
            }
            if (e.Key == Key.A)
            {
                goSx = false;
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
                //if(dirPalla == 2)
                //{
                //    intercPalla2 = true;
                //    dirPalla = 1;
                //}
            }
        }
    }
}
