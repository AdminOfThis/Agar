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
        public String Name { get; private set; }
        public Vector Possition { get; private set; }
        public int Mass { get; private set; }
        private double Speed {
            get {
                return Direction.Length;
            }
        }
        public Vector Direction { get; set; }

        public Player(String Name)
        {
            Console.WriteLine("New player");
            World.Instance.Players.Add(this);
            this.Name = Name;
            Direction = new Vector();
            Possition = new Vector(World.WIDTH / 2, World.HEIGHT / 2);
            Mass = 0;
        }
        /**
         * Moves the player depending on Speed and Direction, should be called every tick
         * */
        public void move()
        {
            Possition = Possition + Direction;
        }

        /**
         * Eats another player and adds its mass to the current player
         * */
        public void eat(Player otherPlayer)
        {
            this.Mass += otherPlayer.Mass;
        }

        /**
         * Eats food and adds its mass to the current player
         * */
        public void eat(Food food)
        {
            this.Mass += Food.Mass;
        }


    }
}
