using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    class Program
    {

        public static void Serialize(Game game)
        {
            FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);            
            XmlSerializer xs = new XmlSerializer(typeof(Game));            
            xs.Serialize(fs, game);
            fs.Close();            
        }

        public static Game Deserialize()
        {
            FileStream fs = new FileStream("save.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            Game game2 = new Game();
            game2 = xs.Deserialize(fs) as Game;
            fs.Close();
            return game2;            
        }

        static void Main(string[] args)
        {           
            int l;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose level (1-5)");
                l = int.Parse(Console.ReadLine());
                if (l > 0 && l <= 5)
                    break;
            }

            Wall wall = new Wall(l);
            Worm worm = new Worm();
            Food food = new Food();
            worm.Start();

            string way = "none";

            bool f0 = true;
            while (f0 == true)
            {                
                worm = new Worm();
                food = new Food();
                worm.Start();
                f0 = false;
                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].Equals(worm.body[0]))
                        f0 = true;
            }

            bool s0 = true;
            bool s1 = true;
            while (s0 == true || s1 == true)
            {
                worm = new Worm();
                worm.Start();
                s0 = false;
                s1 = false;
                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].Equals(worm.body[0]))
                        s0 = true;
                if (worm.body[0].Equals(food.location))
                    s1 = true;
            }           

            while (worm.isAlive)
            {                
                Console.Clear();                
                worm.Draw();                               
                food.Draw();                                                                                
                wall.Draw();                                

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (way != "down"  || worm.body.Count == 1)
                        {
                            worm.Move(0, -1);
                            way = "up";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (way != "up" || worm.body.Count == 1)
                        {
                            worm.Move(0, 1);
                            way = "down";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (way != "right" || worm.body.Count == 1)
                        {
                            worm.Move(-1, 0);
                            way = "left";
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (way != "left" || worm.body.Count == 1)
                        {
                            worm.Move(1, 0);
                            way = "right";
                        }
                        break;
                    case ConsoleKey.Escape:
                        worm.isAlive = false;
                        break;
                    case ConsoleKey.F5:
                        Game game = new Game(food, wall, worm);
                        Serialize(game);
                        break;
                    case ConsoleKey.F9:
                        Game game2 = Deserialize();                                              
                        food = game2.food;
                        wall = game2.wall;
                        worm = game2.worm;
                        break;
                }

                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].Equals(worm.body[0]))
                    {
                        worm.isAlive = false;
                    }

                for (int i = 1; i < worm.body.Count; i++)
                {
                    if (worm.body[0].Equals(worm.body[i]))
                        worm.isAlive = false;
                }

                if (worm.CanEat(food))
                {
                    bool f1 = true;
                    bool f2 = true;
                    while (f1==true || f2==true)
                    {
                        f1 = false;
                        f2 = false;
                        food = new Food();
                        for (int i = 0; i < worm.body.Count; i++)
                            if (worm.body[i].Equals(food.location))
                                f1=true;

                        for (int i = 0; i < wall.bricks.Count; i++)
                            if (wall.bricks[i].Equals(food.location))
                                f2 = true;
                    }                  
                }
            }

            Console.Clear();
            Console.WriteLine("GAME OVER");

        }
    }
}
