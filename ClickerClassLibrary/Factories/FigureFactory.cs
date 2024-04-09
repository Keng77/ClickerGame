using FiguresClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary
{
    public abstract class FigureFactory
    {
        public abstract Figure CreateFigure(Pnt[] pnts, Color color, int ttl);
    }
}
