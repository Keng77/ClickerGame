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

        private Square(Pnt[] pnts) : base(pnts) //конструктор класса, принимающий масив точек
        {
            calcLen();
        }

        private Square(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl) //конструктор класса, принимающий масив точек
        {
            calcLen();
        }

        public Square(Pnt first, Pnt second) : this(new Pnt[2] { first, second }) //конструктор #1 с перегрузкой
        {
        }

        public Square(Pnt first, Pnt second, Color color, int ttl) : this(new Pnt[2] { first, second }, color, ttl) //конструктор #1 с перегрузкой
        {
        }

        public Square(double x1, double y1, double x2, double y2) : this(new Pnt[2] { new Pnt(x1, y1), new Pnt(x2, y2) }) //конструктор #2 с перегрузкой
        {
        }

        public Square(double x1, double y1, double x2, double y2, Color color, int ttl) : this(new Pnt[2] { new Pnt(x1, y1), new Pnt(x2, y2) }, color, ttl) //конструктор #2 с перегрузкой
        {
        }

        private void calcLen()
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

        public override bool isContain(Pnt pnt)
        {
            bool isCnt = false;

            if (((pnts[0].x <= pnt.x) && (pnts[1].x >= pnt.x)) && ((pnts[0].y <= pnt.y) && (pnts[1].y >= pnt.y))) isCnt = true;

            return isCnt;
        }
        public override int GetCost()
        {
            return (int)(GetS() * 0.1);
        }
    }
}
