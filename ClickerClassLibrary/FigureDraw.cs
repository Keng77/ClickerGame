﻿using System;
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
                int x1 = Convert.ToInt32(circle.GetCenter().x);
                int y1 = Convert.ToInt32(circle.GetCenter().y);

                int r = Convert.ToInt32(circle.GetR());

                x1 = x1 - r;
                y1 = y1 - r;

                g.FillEllipse(brush, x1, y1, 2 * r, 2 * r);
            }
            else
            {
                if (figure is Rctngl)
                {

                    Rctngl circle = (Rctngl)figure; //Приводим тип фигура к прямоугольнику

                    int x1 = Convert.ToInt32(circle.pnts[0].x);
                    int y1 = Convert.ToInt32(circle.pnts[0].y);
                    int x2 = Convert.ToInt32(circle.pnts[1].x);
                    int y2 = Convert.ToInt32(circle.pnts[1].y);

                    g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
                }
                else
                {
                    if (figure is Square)
                    {
                        Square circle = (Square)figure; //Приводим тип фигура к квадрату

                        int x1 = Convert.ToInt32(circle.pnts[0].x);
                        int y1 = Convert.ToInt32(circle.pnts[0].y);
                        int x2 = Convert.ToInt32(circle.pnts[1].x);
                        int y2 = Convert.ToInt32(circle.pnts[1].y);

                        g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
                    }
                    else
                    {
                        if (figure is Triangle)
                        {
                            Triangle circle = (Triangle)figure; //Приводим тип фигура к треугольнику

                            PointF point0 = new PointF(Convert.ToInt32(circle.pnts[0].x), Convert.ToInt32(circle.pnts[0].y));
                            PointF point1 = new PointF(Convert.ToInt32(circle.pnts[1].x), Convert.ToInt32(circle.pnts[1].y));
                            PointF point2 = new PointF(Convert.ToInt32(circle.pnts[2].x), Convert.ToInt32(circle.pnts[2].y));
                            PointF[] pointFs = { point0, point1, point2 };

                            g.FillPolygon(brush, pointFs);
                        }
                    }
                }
            }
        }
        public static void Draw(Graphics g, Figure figure) 
        {                                                   

            Draw(g, figure, figure.color); //переопределение метода Draw

        }

    }
}
