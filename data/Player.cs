using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agar.data
{
    class Player
    {
        private String Name { get; set; }
        private double X { get; set; }
        private double Y { get; set; }
        private int Mass { get; set; }
        private double Speed { get; set; }
        private double Direction { get; set; }

        public Player(String Name)
        {
            this.Name = Name;
            Speed = 0;
            Direction = 0;
            X = 0;
            Y = 0;
            Mass = 0;
        }
        /**
         * Moves the player depending on Speed and Direction, should be called every tick
         * */
        public void move()
        {

        }
    }
}
