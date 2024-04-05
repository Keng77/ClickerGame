using System;
using System.Collections.Generic;
using System.Drawing;

namespace FiguresClassLibrary
{
    public class FiguresList
    {
        private static Random rnd = new Random(DateTime.Now.Millisecond);

        public List<Figure> figures { get; private set; } //список

        public FiguresList()
        {
            figures = new List<Figure>();
        }

        public FiguresList(List<Figure> figures)
        {
            this.figures = figures;
        }

        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }

        public void RemoveFigure(Figure figure)
        {
            figures.Remove(figure);
        }

        public void RemoveFigure(Queue<Figure> rFigures) // Удаление  фигуры из списка
        {
            while (rFigures.Count > 0)
            {
                Figure f = rFigures.Dequeue();
                RemoveFigure(f);
            }
        }

        public double GetAvgP()
        {
            double sum = 0;

            foreach (Figure figure in figures)
            {
                sum += figure.GetP();
            }

            return sum / figures.Count;
        }

        public double GetAvgS()
        {
            double proizv = 0;

            for (int i = 0; i < figures.Count; i++)
            {
                proizv += figures[i].GetS();
            }

            return proizv / figures.Count;

        }

        public void DecTTL()
        {
            foreach (Figure figure in figures)
            {
                figure.DecTTL();
            }
        }

        public Figure FindFigure(Pnt pnt)
        {
            Figure f = null;

            bool finded = false;

            for (int i = 0; i < figures.Count && !finded; i++)
            {
                if (figures[i].isContain(pnt))
                {
                    f = figures[i];
                    finded = true;
                }
            }

            return f;
        }

        public Queue<Figure> GetNotAliveFigures() // Список мёртвых фигур
        {
            Queue<Figure> dFigures = new Queue<Figure>();

            foreach (Figure f in figures)
            {
                if (!f.isAlive()) dFigures.Enqueue(f);
            }

            return dFigures;
        }

        public static Figure GetRndFigure(int width, int height, int sizef)
        {
            Figure figure = null;

            int typeF = rnd.Next(0, 4);
            //typeF = 3;
            int x1 = rnd.Next(sizef, width - sizef);
            int y1 = rnd.Next(sizef, height - sizef);
            int x2 = rnd.Next(sizef, width - sizef);
            int y2 = rnd.Next(sizef, height - sizef);

            Color color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            int ttl = rnd.Next(3, 10);

            switch (typeF)
            {
                // Circle
                case 0:
                    int r = rnd.Next(sizef, Math.Min(width, height) - sizef);

                    figure = new Circle(x1, y1, r, color, ttl);
                    break;

                // Rectangle
                case 1:
                    figure = new Rctngl(x1, y1, x2, y2, color, ttl);
                    break;

                // Square
                case 2:
                    figure = new Square(x1, y1, x2, y2, color, ttl);
                    break;

                // Triangle
                case 3:
                    int x3 = rnd.Next(sizef, width - sizef);
                    int y3 = rnd.Next(sizef, height - sizef);

                    figure = new Triangle(x1, y1, x2, y2, x3, y3, color, ttl);
                    break;
            }

            return figure;
        }
    }
}
