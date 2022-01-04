using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSoccer
{
    class Punteggio
    {
        public int punteggioSquadra1 { get; set; }
        public int punteggioSquadra2 { get; set; }

        public Punteggio(int punteggioSquadra1, int punteggioSquadra2)
        {
            this.punteggioSquadra1 = punteggioSquadra1;
            this.punteggioSquadra2 = punteggioSquadra2;
        }
    }
}
