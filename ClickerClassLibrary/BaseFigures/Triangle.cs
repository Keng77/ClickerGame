using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Triangle : Figure
    {
        private double _lenA;
        private double _lenB;
        private double _lenC;        

        public Triangle(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl) //конструктор класса, принимающий масив точек
        {
            CalcLen();
        }

        private void CalcLen()
        {
            _lenA = pnts[0].ToLen(pnts[1]);
            _lenB = pnts[1].ToLen(pnts[2]);
            _lenC = pnts[0].ToLen(pnts[2]);
        }

        public override double GetP()
        {
            return (_lenA + _lenB + _lenC);
        }

        public override double GetS()
        {
            double p = GetP() / 2;
            return Math.Sqrt(p * (p - _lenA) * (p - _lenB) * (p - _lenC));
        }
        public override bool IsContain(Pnt pnt)
        {
            double alpha = ((pnts[1].Y - pnts[2].Y) * (pnt.X - pnts[2].X) +
                            (pnts[2].X - pnts[1].X) * (pnt.Y - pnts[2].Y)) /
                           ((pnts[1].Y - pnts[2].Y) * (pnts[0].X - pnts[2].X) +
                            (pnts[2].X - pnts[1].X) * (pnts[0].Y - pnts[2].Y));

            double beta = ((pnts[2].Y - pnts[0].Y) * (pnt.X - pnts[2].X) +
                           (pnts[0].X - pnts[2].X) * (pnt.Y - pnts[2].Y)) /
                          ((pnts[1].Y - pnts[2].Y) * (pnts[0].X - pnts[2].X) +
                           (pnts[2].X - pnts[1].X) * (pnts[0].Y - pnts[2].Y));

            double gamma = 1.0 - alpha - beta;

            return alpha >= 0 && beta >= 0 && gamma >= 0;
        }

        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4));
        }
    }
}
