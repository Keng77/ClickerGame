using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Square : Figure
    {
        private double _lenA;        

        public Square(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl) //конструктор класса, принимающий масив точек
        {
            CalcLen();
        }


        private void CalcLen()
        {
            this._lenA = pnts[0].ToLen(pnts[1]);
        }

        public override double GetP()
        {
            return (4 * _lenA);
        }

        public override double GetS()
        {
            return Math.Pow(_lenA, 2);
        }

        public override bool IsContain(Pnt pnt)
        {
            bool isCnt = false;

            if (((pnts[0].X <= pnt.X) && (pnts[1].X >= pnt.X)) && ((pnts[0].Y <= pnt.Y) && (pnts[1].Y >= pnt.Y))) isCnt = true;

            return isCnt;
        }

        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4));
        }
    }
}
