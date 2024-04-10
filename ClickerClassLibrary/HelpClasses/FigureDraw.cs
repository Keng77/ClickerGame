using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    public static class FigureDraw
    {
        public static void Draw(Graphics g, Figure figure, Color color)
        {
            SolidBrush brush = new SolidBrush(color);

            if (figure is Circle circle)
            {
                DrawCircle(g, circle, brush);
            }
            else if (figure is Square square)
            {
                DrawSquare(g, square, brush);
            }
            else if (figure is Rectangle rectangle)
            {
                DrawRectangle(g, rectangle, brush);
            }
            else if (figure is Triangle triangle)
            {
                DrawTriangle(g, triangle, brush);
            }
            else if (figure is FigureDecorator decorator)
            {
                Draw(g, decorator.decoratedFigure, color);
            }
        }

        public static void Draw(Graphics g, Figure figure)
        {
            Draw(g, figure, figure.Color);
        }

        private static void DrawCircle(Graphics g, Circle circle, SolidBrush brush)
        {
            int x1 = Convert.ToInt32(circle.GetCenter().X);
            int y1 = Convert.ToInt32(circle.GetCenter().Y);
            int r = Convert.ToInt32(circle.GetR());

            x1 -= r;
            y1 -= r;

            g.FillEllipse(brush, x1, y1, 2 * r, 2 * r);
        }

        private static void DrawSquare(Graphics g, Square square, SolidBrush brush)
        {
            int x1 = Convert.ToInt32(square.pnts[0].X);
            int y1 = Convert.ToInt32(square.pnts[0].Y);
            int x2 = Convert.ToInt32(square.pnts[1].X);
            int y2 = Convert.ToInt32(square.pnts[1].Y);

            g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
        }

        private static void DrawRectangle(Graphics g, Rectangle rectangle, SolidBrush brush)
        {
            int x1 = Convert.ToInt32(rectangle.pnts[0].X);
            int y1 = Convert.ToInt32(rectangle.pnts[0].Y);
            int x2 = Convert.ToInt32(rectangle.pnts[1].X);
            int y2 = Convert.ToInt32(rectangle.pnts[1].Y);

            g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
        }

        private static void DrawTriangle(Graphics g, Triangle triangle, SolidBrush brush)
        {
            PointF point0 = new PointF(Convert.ToInt32(triangle.pnts[0].X), Convert.ToInt32(triangle.pnts[0].Y));
            PointF point1 = new PointF(Convert.ToInt32(triangle.pnts[1].X), Convert.ToInt32(triangle.pnts[1].Y));
            PointF point2 = new PointF(Convert.ToInt32(triangle.pnts[2].X), Convert.ToInt32(triangle.pnts[2].Y));
            PointF[] pointFs = { point0, point1, point2 };

            g.FillPolygon(brush, pointFs);
        }
    }
}