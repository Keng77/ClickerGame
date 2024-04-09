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
            calcLen();
        }

        private void calcLen()
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
            double alpha = ((pnts[1].y - pnts[2].y) * (pnt.x - pnts[2].x) +
                            (pnts[2].x - pnts[1].x) * (pnt.y - pnts[2].y)) /
                           ((pnts[1].y - pnts[2].y) * (pnts[0].x - pnts[2].x) +
                            (pnts[2].x - pnts[1].x) * (pnts[0].y - pnts[2].y));

            double beta = ((pnts[2].y - pnts[0].y) * (pnt.x - pnts[2].x) +
                           (pnts[0].x - pnts[2].x) * (pnt.y - pnts[2].y)) /
                          ((pnts[1].y - pnts[2].y) * (pnts[0].x - pnts[2].x) +
                           (pnts[2].x - pnts[1].x) * (pnts[0].y - pnts[2].y));

            double gamma = 1.0 - alpha - beta;

            return alpha >= 0 && beta >= 0 && gamma >= 0;
        }

        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4));
        }
    }
}
