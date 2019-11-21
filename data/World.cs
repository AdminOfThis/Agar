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

        private static World Instance;

        private List<Player> players = new List<Player>();
        public static World getInstance()
        {
            if (Instance == null)
            {
                Instance = new World();
            }
            return Instance;
        }

        private World()
        { }

    }
}
