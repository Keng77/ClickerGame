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
        private double _lenA; 
        private double _lenB;        

        public Rctngl(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
        {
            calcLen();
        }
                

        private void calcLen()
        {
            Pnt upRight = new Pnt(pnts[1].x, pnts[0].y);

            this._lenA = upRight.ToLen(pnts[0]);
            this._lenB = upRight.ToLen(pnts[1]);
        }

        public override double GetP()
        {
            return 2 * (_lenA + _lenB);
        }

        public override double GetS()
        {
            return _lenA * _lenB;
        }

        public override bool isContain(Pnt pnt)
        {
            bool isCnt = false;

            if (((pnts[0].x <= pnt.x) && (pnts[1].x >= pnt.x)) && ((pnts[0].y <= pnt.y) && (pnts[1].y >= pnt.y))) isCnt = true;

            return isCnt;
        }

        public override int GetCost()
        {
            return (int)(1000 / GetS() +1);
        }

    }
}
