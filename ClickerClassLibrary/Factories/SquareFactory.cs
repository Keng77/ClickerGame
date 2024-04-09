using FigureClassLibrary;
using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    public class SquareFactory : FigureFactory
    {
        public override Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 2)
            {
                throw new ArgumentException("Количество точек должно быть = 2.");
            }

            return new Square(pnts, color, ttl);
        }
    }
}