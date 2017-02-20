using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Wall
    {
        
        public char sign = '█';
        public List<Point> bricks = new List<Point>();

        public Wall() { }

        public Wall(int level)
        {
            string fname = string.Format(@"Levels\level{0}.txt",level);
            using(FileStream fs = new FileStream(fname,FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    int colNumber = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        for (int rowNumber = 0; rowNumber < line.Length; ++rowNumber)
                        {
                            if (line[rowNumber] == '#')
                            {
                                bricks.Add(new Point(rowNumber, colNumber));
                            }
                        }

                        colNumber++;
                    }
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < bricks.Count; ++i)
            {
                Console.SetCursorPosition(bricks[i].x, bricks[i].y);
                Console.Write(sign);
            }
        }
    }
}
