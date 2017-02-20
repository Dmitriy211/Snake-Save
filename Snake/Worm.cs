using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Worm
    {
        public char sign = '*';
        public List<Point> body = new List<Point>();
        public bool isAlive = true;
        
        public void Start()
        {
            body.Add(new Point(new Random().Next() % 8 + 1, new Random().Next() % 8 + 1));
        }

        public Worm() { }

        public void Draw()
        {
            for (int i = 0; i < body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(sign);
                Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
                Console.Write("■");
                Console.SetCursorPosition(body[0].x, body[0].y);
                Console.Write("☻");                
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void Move(int dx, int dy)
        {
            if (body[0].x + dx < 0) return;
            if (body[0].y + dy < 0) return;
            if (body[0].x + dx > 10) return;
            if (body[0].y + dy > 10) return;

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

        }

        public bool CanEat(Food food)
        {            
            if (body[0].Equals(food.location))
            {
                body.Add(food.location);
                return true;
            }
            return false;
        }
    }
}
