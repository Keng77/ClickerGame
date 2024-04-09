using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Pnt
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Pnt(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double ToLen(double x, double y)
        {
            double len = Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2));
            return len;
        }

        public double ToLen(Pnt pnt) //метод, вычисляющий длину между предыдущей точкой и заданной
        {
            return ToLen(pnt.X, pnt.Y);
        }
    }
}
