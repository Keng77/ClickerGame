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

        public Circle(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
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
            return (int)(1000 / GetS() + 1);
        }
    }
}
