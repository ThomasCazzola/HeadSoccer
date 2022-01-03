using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Palla(int pos_X, int pos_Y, int vel, BitmapImage image)
        {
            this.pos_X = pos_X;
            this.pos_Y = pos_Y;
            this.vel = vel;
            this.image = image;
            this.direzione = GeneraDirPallaRandom();
        }

        private int GeneraDirPallaRandom()
        {
            int tempDirezione = random.Next(2) + 1;
            return tempDirezione;
        }
    }
}
