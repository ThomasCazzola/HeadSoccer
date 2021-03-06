using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeadSoccer
{
    public class Giocatore
    {
        public string Nome { get; set; }
        public BitmapImage Immagine { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int Vel { get; set; }
        public string mossaSpeciale { get; set; }

        public Giocatore()
        {
            Nome = "";
            Immagine = null;
            this.posX = 0;
            this.posY = 0;
            Vel = 0;
            mossaSpeciale = "";
        }

        public Giocatore(string nome, BitmapImage immagine, int posX, int posY, int vel, string mossaspeciale)
        {
            Nome = nome;
            Immagine = immagine;
            this.posX = posX;
            this.posY = posY;
            Vel = vel;
            mossaSpeciale = mossaspeciale;
        }


    }
}
