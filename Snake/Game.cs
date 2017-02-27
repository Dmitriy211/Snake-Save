using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Game
    {
        public Food food;
        public Wall wall;
        public Worm worm;
        public int score;
        public int l;

        public Game() { }

        public Game(Food food, Wall wall, Worm worm, int score, int l)
        {
            this.food = food;
            this.wall = wall;
            this.worm = worm;
            this.score = score;
            this.l = l;
        }
    }
}
