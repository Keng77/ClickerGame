using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{

    public static class FigureDraw
    {
        public static void Draw(Graphics g, Figure figure, Color color)
        {
            SolidBrush brush = new SolidBrush(color);

            if (figure is Circle) 
            {

                Circle circle = (Circle)figure; //Приводим тип фигура к окружности
                int x1 = Convert.ToInt32(circle.GetCenter().X);
                int y1 = Convert.ToInt32(circle.GetCenter().Y);

                int r = Convert.ToInt32(circle.GetR());

                x1 -= r;
                y1 -= r;

                g.FillEllipse(brush, x1, y1, 2 * r, 2 * r);
            }
            else
            {
                if (figure is Rectangle)
                {

                    Rectangle circle = (Rectangle)figure; //Приводим тип фигура к прямоугольнику

                    int x1 = Convert.ToInt32(circle.pnts[0].X);
                    int y1 = Convert.ToInt32(circle.pnts[0].Y);
                    int x2 = Convert.ToInt32(circle.pnts[1].X);
                    int y2 = Convert.ToInt32(circle.pnts[1].Y);

                    g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
                }
                else
                {
                    if (figure is Square)
                    {
                        Square circle = (Square)figure; //Приводим тип фигура к квадрату

                        int x1 = Convert.ToInt32(circle.pnts[0].X);
                        int y1 = Convert.ToInt32(circle.pnts[0].Y);
                        int x2 = Convert.ToInt32(circle.pnts[1].X);
                        int y2 = Convert.ToInt32(circle.pnts[1].Y);

                        g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
                    }
                    else
                    {
                        //Приводим тип фигура к треугольнику
                        if (figure is Triangle circle)
                        {
                            PointF point0 = new PointF(Convert.ToInt32(circle.pnts[0].X), Convert.ToInt32(circle.pnts[0].Y));
                            PointF point1 = new PointF(Convert.ToInt32(circle.pnts[1].X), Convert.ToInt32(circle.pnts[1].Y));
                            PointF point2 = new PointF(Convert.ToInt32(circle.pnts[2].X), Convert.ToInt32(circle.pnts[2].Y));
                            PointF[] pointFs = { point0, point1, point2 };

                            g.FillPolygon(brush, pointFs);
                        }
                    }
                }
            }
        }
        public static void Draw(Graphics g, Figure figure) 
        {                                                   

            Draw(g, figure, figure.Color); //переопределение метода Draw

        }

    }
}
