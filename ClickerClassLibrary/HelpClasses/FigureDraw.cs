using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    public static class FigureDraw
    {
        /// <summary>
        /// Рисует фигуру на графическом объекте с заданным цветом.
        /// </summary>
        /// <param name="g">Графический объект, на котором будет отображаться фигура.</param>
        /// <param name="figure">Фигура, которую нужно нарисовать.</param>
        /// <param name="color">Цвет, которым будет заполнена фигура.</param>
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

        /// <summary>
        /// Рисует фигуру на графическом объекте с использованием цвета фигуры.
        /// </summary>
        /// <param name="g">Графический объект, на котором будет отображаться фигура.</param>
        /// <param name="figure">Фигура, которую нужно нарисовать.</param>
        public static void Draw(Graphics g, Figure figure)
        {
            Draw(g, figure, figure.Color);
        }

        /// <summary>
        /// Рисует круг на графическом объекте с заданным цветом.
        /// </summary>
        /// <param name="g">Графический объект, на котором будет отображаться круг.</param>
        /// <param name="circle">Круг, который нужно нарисовать.</param>
        /// <param name="brush">Кисть, которой будет заполнен круг.</param>
        private static void DrawCircle(Graphics g, Circle circle, SolidBrush brush)
        {
            int x1 = Convert.ToInt32(circle.GetCenter().X);
            int y1 = Convert.ToInt32(circle.GetCenter().Y);
            int r = Convert.ToInt32(circle.GetR());

            x1 -= r;
            y1 -= r;

            g.FillEllipse(brush, x1, y1, 2 * r, 2 * r);
        }
        /// <summary>
        /// Рисует квадрат на графическом объекте с заданным цветом.
        /// </summary>
        /// <param name="g">Графический объект, на котором будет отображаться квадрат.</param>
        /// <param name="square">Квадрат, который нужно нарисовать.</param>
        /// <param name="brush">Кисть, которой будет заполнен квадрат.</param>
        private static void DrawSquare(Graphics g, Square square, SolidBrush brush)
        {
            int x1 = Convert.ToInt32(square.pnts[0].X);
            int y1 = Convert.ToInt32(square.pnts[0].Y);
            int x2 = Convert.ToInt32(square.pnts[1].X);
            int y2 = Convert.ToInt32(square.pnts[1].Y);

            g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
        }
        /// <summary>
        /// Рисует прямоугольник на графическом объекте с заданным цветом.
        /// </summary>
        /// <param name="g">Графический объект, на котором будет отображаться прямоугольник.</param>
        /// <param name="rectangle">Прямоугольник, который нужно нарисовать.</param>
        /// <param name="brush">Кисть, которой будет заполнен прямоугольник.</param>
        private static void DrawRectangle(Graphics g, Rectangle rectangle, SolidBrush brush)
        {
            int x1 = Convert.ToInt32(rectangle.pnts[0].X);
            int y1 = Convert.ToInt32(rectangle.pnts[0].Y);
            int x2 = Convert.ToInt32(rectangle.pnts[1].X);
            int y2 = Convert.ToInt32(rectangle.pnts[1].Y);

            g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
        }
        /// <summary>
        /// Рисует треугольник на графическом объекте с заданным цветом.
        /// </summary>
        /// <param name="g">Графический объект, на котором будет отображаться треугольник.</param>
        /// <param name="triangle">Треугольник, который нужно нарисовать.</param>
        /// <param name="brush">Кисть, которой будет заполнен треугольник.</param>
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