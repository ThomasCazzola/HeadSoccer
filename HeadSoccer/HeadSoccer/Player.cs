using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSoccer
{
    class Player
    {
        public string name { get; set; }
        public int pos_X { get; set; }
        public int pos_Y { get; set; }
        public int velocity { get; set; }

        public Player(string name, int pos_X, int pos_Y, int velocity)
        {
            this.name = name;
            this.pos_X = pos_X;
            this.pos_Y = pos_Y;
            this.velocity = velocity;
        }

        public Player()
        {
            name = "";
            pos_X = 100;
            pos_Y = 30;
            velocity = 0;
        }
    }
}
