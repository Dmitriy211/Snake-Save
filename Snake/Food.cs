using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Food
    {
        public Point location;
        public char sign = '♥';
        public Food()
        {
            location = new Point(new Random().Next() % 8 + 1, new Random().Next() % 8 + 1);
        }
        public void Draw()
        {
            Console.SetCursorPosition(location.x, location.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sign);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}