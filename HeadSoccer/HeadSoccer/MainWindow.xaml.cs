using System;
using System.Diagnostics;
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
        DispatcherTimer gameTimer = new DispatcherTimer(DispatcherPriority.Normal);
        DispatcherTimer tempoRimanente = new DispatcherTimer(DispatcherPriority.Normal);
        //bool gameOver = false;
        bool goDx, goSx;
        int gravity = 8;
        Rect playerHitBox, ballHitBox, groundSxHitBox, groundDxHitBox, portaSxHitbox, portaDxHitbox, topSxHitBox, topDxHitBox, latoSxAltoHitBox, latoSxBassoHitBox, latoDxAltoHitbox, latoDxBassoHitBox; //groundTopHitBox;
        Random r = new Random();
        Giocatore giocatore = null;
        Palla palla = null;
        Punteggio punteggio = null;
        string currentTime = string.Empty;
        Stopwatch stopwatch = new Stopwatch();

        public MainWindow(int index)
        {
            InitializeComponent();
            ControllaGiocatoreSelezionato(index);
            gameTimer.Tick += gameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            tempoRimanente.Tick += new EventHandler(StopWatch);
            tempoRimanente.Interval = new TimeSpan(0, 0, 0, 0, 1);
            StartGame();
            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.ActualWidth, Player.ActualHeight);
            ballHitBox = new Rect(Canvas.GetLeft(Palla), Canvas.GetLeft(Palla), Palla.ActualWidth, Palla.ActualHeight);
            groundSxHitBox = new Rect(Canvas.GetLeft(GroundSx), Canvas.GetTop(GroundSx), GroundSx.ActualWidth, GroundSx.ActualHeight);
            groundDxHitBox = new Rect(Canvas.GetLeft(GroundDx), Canvas.GetTop(GroundDx), GroundDx.ActualWidth, GroundDx.ActualHeight);
            topSxHitBox = new Rect(Canvas.GetLeft(TopSx), Canvas.GetTop(TopSx), TopSx.ActualWidth, TopSx.ActualHeight);
            topDxHitBox = new Rect(Canvas.GetLeft(TopDx), Canvas.GetTop(TopDx), TopDx.ActualWidth, TopDx.ActualHeight);
            portaSxHitbox = new Rect(Canvas.GetLeft(portaSx), Canvas.GetTop(portaSx), portaSx.ActualWidth, portaSx.ActualHeight);
            portaDxHitbox = new Rect(Canvas.GetLeft(portaDx) + 50, Canvas.GetTop(portaDx), portaDx.ActualWidth, portaDx.ActualHeight);
            latoSxAltoHitBox = new Rect(Canvas.GetLeft(latoSxAlto), Canvas.GetTop(latoSxAlto), latoSxAlto.ActualWidth, latoSxAlto.ActualHeight);
            latoSxBassoHitBox = new Rect(Canvas.GetLeft(latoSxBasso), Canvas.GetTop(latoSxBasso), latoSxBasso.ActualWidth, latoSxBasso.ActualHeight);
            latoDxAltoHitbox = new Rect(Canvas.GetLeft(latoDxAlto), Canvas.GetTop(latoDxAlto), latoDxAlto.ActualWidth, latoDxAlto.ActualHeight);
            latoDxBassoHitBox = new Rect(Canvas.GetLeft(latoDxBasso), Canvas.GetTop(latoDxBasso), latoDxBasso.ActualWidth, latoDxBasso.ActualHeight);
        }

        private void StopWatch(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                labelTimer.Content = currentTime;
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            playerHitBox.X = Canvas.GetLeft(Player); playerHitBox.Y = Canvas.GetTop(Player); playerHitBox.Width = Player.ActualWidth; playerHitBox.Height = Player.ActualHeight;
            ballHitBox.X = Canvas.GetLeft(Palla); ballHitBox.Y = Canvas.GetTop(Palla); ballHitBox.Width = Palla.ActualWidth; ballHitBox.Height = Palla.ActualHeight;
            groundSxHitBox.X = Canvas.GetLeft(GroundSx); groundSxHitBox.Y = Canvas.GetTop(GroundSx); groundSxHitBox.Width = GroundSx.ActualWidth; groundSxHitBox.Height = GroundSx.ActualHeight;
            groundDxHitBox.X = Canvas.GetLeft(GroundDx); groundDxHitBox.Y = Canvas.GetTop(GroundDx); groundDxHitBox.Width = GroundDx.ActualWidth; groundDxHitBox.Height = GroundDx.ActualHeight;
            portaSxHitbox.X = Canvas.GetLeft(portaSx); portaSxHitbox.Y = Canvas.GetTop(portaSx); portaSxHitbox.Width = portaSx.ActualWidth; portaSxHitbox.Height = portaSx.ActualHeight;
            portaDxHitbox.X = Canvas.GetLeft(portaDx); portaDxHitbox.Y = Canvas.GetTop(portaDx); portaDxHitbox.Width = portaDx.ActualWidth; portaDxHitbox.Height = portaDx.ActualHeight;
            topSxHitBox.X = Canvas.GetLeft(TopSx); topSxHitBox.Y = Canvas.GetTop(TopSx); topSxHitBox.Width = TopSx.ActualWidth; topSxHitBox.Height = TopSx.ActualHeight;
            topDxHitBox.X = Canvas.GetLeft(TopDx); topDxHitBox.Y = Canvas.GetTop(TopDx); topDxHitBox.Width = TopDx.ActualWidth; topDxHitBox.Height = TopDx.ActualHeight;
            latoSxAltoHitBox.X = Canvas.GetLeft(latoSxAlto); latoSxAltoHitBox.Y = Canvas.GetTop(latoSxAlto); latoSxAltoHitBox.Width = latoSxAlto.ActualWidth; latoSxAltoHitBox.Height = TopDx.ActualHeight;
            latoSxBassoHitBox.X = Canvas.GetLeft(latoSxBasso); latoSxBassoHitBox.Y = Canvas.GetTop(latoSxBasso); latoSxBassoHitBox.Width = latoSxBasso.ActualWidth; latoSxBassoHitBox.Height = latoSxBasso.ActualHeight;
            latoDxAltoHitbox.X = Canvas.GetLeft(latoDxAlto); latoDxAltoHitbox.Y = Canvas.GetTop(latoDxAlto); latoDxAltoHitbox.Width = latoDxAlto.ActualWidth; latoDxAltoHitbox.Height = latoDxAlto.ActualHeight;
            latoDxBassoHitBox.X = Canvas.GetLeft(latoDxBasso); latoDxBassoHitBox.Y = Canvas.GetTop(latoDxBasso); latoDxBassoHitBox.Width = latoDxBasso.ActualWidth; latoDxBassoHitBox.Height = latoDxBasso.ActualHeight;

            Canvas.SetTop(Player, Canvas.GetTop(Player) + gravity);
            if (goDx)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + giocatore.Vel);
            }
            if (goSx)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - giocatore.Vel);
            }
            palla.SetDirezione();
            Canvas.SetTop(Palla, palla.pos_X);
            Canvas.SetLeft(Palla, palla.pos_Y);
            Intersezioni();
            labelSquadra1.Content = "SQUADRA 1: " + punteggio.punteggioSquadra1;
            labelSquadra2.Content = "SQUADRA 2: " + punteggio.punteggioSquadra2;
            labelTimer.Content = "00:00";
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
                    gravity = -8;
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
            stopwatch.Start();
            tempoRimanente.Start();
            myCanvas.Focus();
            Canvas.SetTop(Player, giocatore.posX);
            Canvas.SetLeft(Player, giocatore.posY);
            palla = new Palla(460, 910, 4, new BitmapImage(new Uri(@"images/palla.png", UriKind.Relative)));
            Canvas.SetTop(Palla, palla.pos_X);
            Canvas.SetLeft(Palla, palla.pos_Y);
            palla.GeneraDirPallaRandom();
            punteggio = new Punteggio(0, 0);
        }

        private void EndGame()
        {
            //gameOver = true;
        }

        private void Intersezioni()
        {
            if (playerHitBox.IntersectsWith(groundSxHitBox))
            {
                Canvas.SetTop(Player, Canvas.GetTop(GroundSx) - Player.ActualHeight);
            }
            if (ballHitBox.IntersectsWith(playerHitBox))
            {
                palla.dirX = 1;
                palla.dirY = -1;
            }
            if (ballHitBox.IntersectsWith(portaSxHitbox))
            {
                punteggio.punteggioSquadra2++;
                palla.pos_X = 460;
                palla.pos_Y = 910;
            }
            if (ballHitBox.IntersectsWith(portaDxHitbox))
            {
                punteggio.punteggioSquadra1++;
                palla.pos_X = 460;
                palla.pos_Y = 910;
            }
            if (ballHitBox.IntersectsWith(playerHitBox))
            {
                palla.dirX = 1;
                palla.dirY = -1;
            }
            if (ballHitBox.IntersectsWith(topSxHitBox))
            {
                palla.dirX = -1;
                palla.dirY = 1;
            }
            if (ballHitBox.IntersectsWith(topDxHitBox))
            {
                palla.dirX = -1;
                palla.dirY = -1;
            }
            if (ballHitBox.IntersectsWith(groundSxHitBox))
            {
                palla.dirX = 1;
                palla.dirY = 1;
            }
            if (ballHitBox.IntersectsWith(groundDxHitBox))
            {
                palla.dirX = 1;
                palla.dirY = -1;
            }
        }

        private void ControllaGiocatoreSelezionato(int indexPlayer)
        {
            switch (indexPlayer)
            {
                case 0:
                    return;
                case 1:
                    giocatore = new Giocatore("Player1", new BitmapImage(new Uri(@"images/player1.png", UriKind.Relative)), 900, 200, 10, "Air snow storm shot");
                    Player.Source = giocatore.Immagine;
                    break;
                case 2:
                    giocatore = new Giocatore("Player2", new BitmapImage(new Uri(@"images/player2.png", UriKind.Relative)), 900, 200, 10, "Blue area shot");
                    Player.Source = giocatore.Immagine;
                    break;
                case 3:
                    giocatore = new Giocatore("Player3", new BitmapImage(new Uri(@"images/player3.png", UriKind.Relative)), 900, 200, 10, "Power shots");
                    Player.Source = giocatore.Immagine;
                    break;
                case 4:
                    giocatore = new Giocatore("Player4", new BitmapImage(new Uri(@"images/player4.png", UriKind.Relative)), 900, 200, 10, "Sand shot");
                    Player.Source = giocatore.Immagine;
                    break;
                case 5:
                    giocatore = new Giocatore("Player5", new BitmapImage(new Uri(@"images/player5.png", UriKind.Relative)), 900, 200, 10, "Military shot");
                    Player.Source = giocatore.Immagine;
                    break;
                default:
                    break;
            }
        }
    }
}
