using FigureClassLibrary;
using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    public class RectangleFactory : IFigureFactory
    {
        public Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 2)
            {
                throw new ArgumentException("Количество точек должно быть = 2.");
            }

            return new Rctngl(pnts, color, ttl);
        }
    }
}