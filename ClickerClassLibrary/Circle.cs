using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Circle : Figure
    {
        public Pnt GetCenter()
        {
            return pnts[0];
        }

        public double GetR()
        {
            return pnts[1].x;
        }

        private Circle(Pnt[] pnts) : base(pnts)
        {
        }

        private Circle(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
        {
        }

        public Circle(double x1, double y1, double r) : this(new Pnt[2] { new Pnt(x1, y1), new Pnt(r, r) })
        {
        }

        public Circle(double x1, double y1, double r, Color color, int ttl) : this(new Pnt[2] { new Pnt(x1, y1), new Pnt(r, r) }, color, ttl)
        {
        }

        public override double GetP()
        {
            return 2 * Math.PI * GetR();
        }

        public override double GetS()
        {
            return Math.PI * GetR() * GetR();
        }

        public override bool isContain(Pnt pnt)
        {
            bool isCnt = false;

            double dist = pnt.ToLen(pnts[0]); // Расстояние между центром окружности и точки

            if (Math.Pow(dist, 2) <= Math.Pow(GetR(), 2))
            {
                isCnt = true;
            }

            return isCnt;
        }

        public override int GetCost()
        {
            return (int)(GetS()*0.05);
        }
    }
}
