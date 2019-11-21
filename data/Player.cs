using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agar.data
{
    class Player
    {
        internal object Pos;

        private String Name { get; set; }
        public Vector Position { get; set; }
      private int Mass { get; set; }
        private Vector Direction { get; set; }

        public Player(String Name)
        {
            Console.WriteLine("New player");
            World.Instance.Players.Add(this);
            this.Name = Name;
            Position = new Vector(100,100);
            Direction = new Vector();
            
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
