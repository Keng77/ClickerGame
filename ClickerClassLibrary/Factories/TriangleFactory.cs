using FigureClassLibrary;
using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    public class TriangleFactory : FigureFactory
    {
        public override Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 3)
            {
                throw new ArgumentException("Количество точек должно быть = 3.");
            }

            return new Triangle(pnts, color, ttl);
        }
    }
}