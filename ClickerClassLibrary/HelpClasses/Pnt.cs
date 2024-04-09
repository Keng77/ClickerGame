using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Pnt
    {
        public double x { get; set; }
        public double y { get; set; }

        public Pnt(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double ToLen(double x, double y)
        {
            double len = 0;

            len = Math.Sqrt(Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2));

            return len;
        }

        public double ToLen(Pnt pnt) //метод, вычисляющий длину между предыдущей точкой и заданной
        {
            return ToLen(pnt.x, pnt.y);
        }
    }
}
