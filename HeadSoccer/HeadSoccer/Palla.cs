using System;
using System.Windows.Media.Imaging;

namespace HeadSoccer
{
    class Palla
    {
        public int pos_X { get; set; }
        public int pos_Y { get; set; }
        public int vel { get; set; }
        public BitmapImage image { get; set; }
        public int direzione { get; set; }

        private Random random = new Random();
        
        public int dirX { get; set; }
        public int dirY { get; set; }

        public Palla(int pos_X, int pos_Y, int vel, BitmapImage image)
        {
            this.pos_X = pos_X;
            this.pos_Y = pos_Y;
            this.vel = vel;
            this.image = image;
        }

        public void GeneraDirPallaRandom()
        {
            int tempDirezioneX = random.Next(2) + 1;
            if (tempDirezioneX == 1)
            {
                dirX = -1;
            }
            else if (tempDirezioneX == 2)
            {
                dirX = 1;
            }
            int tempDirezioneY = random.Next(2) + 1;
            if (tempDirezioneY == 1)
            {
                dirY = -1;
            }
            else if (tempDirezioneY == 2)
            {
                dirY = 1;
            }
        }

        public void SetDirezione()
        {
            if (dirX == -1)
            {
                pos_X -= vel;
            }
            if (dirX == 1)
            {
                pos_X += vel;
            }
            if (dirY == -1)
            {
                pos_Y -= vel;
            }
            if (dirY == 1)
            {
                pos_Y += vel;
            }
        }

    }
}
