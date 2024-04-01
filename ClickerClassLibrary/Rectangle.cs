using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Rctngl : Figure
    {
        double lenA; //private (по умолчанию)
        double lenB;

        private Rctngl(Pnt[] pnts) : base(pnts) //конструктор класса, принимающий масив точек
        {
            calcLen();
        }

        private Rctngl(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
        {
            calcLen();
        }

        public Rctngl(Pnt left, Pnt right) : this(new Pnt[2] { left, right }) //конструктор #1 с перегрузкой
        {
        }

        public Rctngl(Pnt left, Pnt right, Color color, int ttl) : this(new Pnt[2] { left, right }, color, ttl) //конструктор #1 с перегрузкой
        {
        }

        public Rctngl(double x1, double y1, double x2, double y2) : this(new Pnt[2] { new Pnt(x1, y1), new Pnt(x2, y2) }) //конструктор #2 с перегрузкой
        {
        }

        public Rctngl(double x1, double y1, double x2, double y2, Color color, int ttl) : this(new Pnt[2] { new Pnt(x1, y1), new Pnt(x2, y2) }, color, ttl) //конструктор #2 с перегрузкой
        {
        }

        private void calcLen()
        {
            Pnt upRight = new Pnt(pnts[1].x, pnts[0].y);

            this.lenA = upRight.ToLen(pnts[0]);
            this.lenB = upRight.ToLen(pnts[1]);
        }

        public override double GetP()
        {
            return 2 * (lenA + lenB);
        }

        public override double GetS()
        {
            return lenA * lenB;
        }

        public override bool isContain(Pnt pnt)
        {
            bool isCnt = false;

            if (((pnts[0].x <= pnt.x) && (pnts[1].x >= pnt.x)) && ((pnts[0].y <= pnt.y) && (pnts[1].y >= pnt.y))) isCnt = true;

            return isCnt;
        }

        public override int GetCost()
        {
            return (int)(GetS() * 0.05);
        }

    }
}
