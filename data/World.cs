using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agar.data
{


    class World
    {
        public const double WIDTH = 400;
        public const double HEIGHT = 400;


        private static World _Instance;
        public static World Instance

        {
            get
            {
                    if (_Instance == null)
                    {
                        //retrieve the configuration file.
                        //load the configuration and return it!
                        _Instance = new World();
                    }
                    else
                    {
                        return _Instance;
                    }
                return Instance;
            }
        }
        private List<Player> players = new List<Player>();
        private List<Food> foods = new List<Food>();


        public List<Player> Players = new List<Player>();

        private World()
        { }

    }
}
