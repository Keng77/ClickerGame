using FigureClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FiguresClassLibrary
{
    public class FiguresList
    {
        private readonly Random rnd = new Random(DateTime.Now.Millisecond);
        private readonly CircleFactory circleFactory;
        private readonly RectangleFactory rectangleFactory;
        private readonly SquareFactory squareFactory;
        private readonly TriangleFactory triangleFactory;

        public List<Figure> Figures { get; private set; } //список фигур

        public FiguresList()
        {
            Figures = new List<Figure>();
            circleFactory = new CircleFactory();
            rectangleFactory = new RectangleFactory();
            squareFactory = new SquareFactory();
            triangleFactory = new TriangleFactory();
        }

        public FiguresList(List<Figure> figures)
        {
            this.Figures = figures;
            circleFactory = new CircleFactory();
            rectangleFactory = new RectangleFactory();
            squareFactory = new SquareFactory();
            triangleFactory = new TriangleFactory();
        }

        public void AddFigure(Figure figure)
        {
            Figures.Add(figure);
        }

        public void RemoveFigure(Figure figure)
        {
            Figures.Remove(figure);
        }

        public void RemoveFigure(Queue<Figure> rFigures) // Удаление  фигуры из списка
        {
            while (rFigures.Count > 0)
            {
                Figure f = rFigures.Dequeue();
                RemoveFigure(f);
            }
        }
       
        public void DecTTL()
        {
            foreach (Figure figure in Figures)
            {
                figure.DecTTL();
            }
        }

        public Figure FindFigure(Pnt pnt)
        {
            Figure f = null;

            bool finded = false;

            for (int i = 0; i < Figures.Count && !finded; i++)
            {
                if (Figures[i].IsContain(pnt))
                {
                    f = Figures[i];
                    finded = true;
                }
            }

            return f;
        }

        public Queue<Figure> GetNotAliveFigures() // Список мёртвых фигур
        {
            Queue<Figure> dFigures = new Queue<Figure>();

            foreach (Figure f in Figures)
            {
                if (!f.IsAlive()) dFigures.Enqueue(f);
            }

            return dFigures;
        }

        public Figure GetRndFigure(int width, int height, int sizef)
        {
            Figure figure = null;

            int typeF = rnd.Next(0, 4);

            int x1 = rnd.Next(sizef, width - sizef);
            int y1 = rnd.Next(sizef, height - sizef);
            int x2 = rnd.Next(sizef, width - sizef);
            int y2 = rnd.Next(sizef, height - sizef);

            Color color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            int ttl = rnd.Next(3, 10);

            bool isDecorated = rnd.Next(1, 101) <= 20; // Шанс декорирования 20%

            switch (typeF)
            {
                case 0:
                    int r = rnd.Next(sizef, Math.Min(width, height) - sizef);
                    Pnt[] pntsCircle = { new Pnt(x1, y1), new Pnt(r, r) }; // Пример точек для круга
                    figure = circleFactory.CreateFigure(pntsCircle, color, ttl);
                    break;

                case 1:
                    Pnt[] pntsRectangle = { new Pnt(x1, y1), new Pnt(x2, y2) }; // Пример точек для прямоугольника
                    figure = rectangleFactory.CreateFigure(pntsRectangle, color, ttl);
                    break;

                case 2:
                    Pnt[] pntsSquare = { new Pnt(x1, y1), new Pnt(x2, y2) }; // Пример точек для квадрата
                    figure = squareFactory.CreateFigure(pntsSquare, color, ttl);
                    break;

                case 3:
                    int x3 = rnd.Next(sizef, width - sizef);
                    int y3 = rnd.Next(sizef, height - sizef);
                    Pnt[] pntsTriangle = { new Pnt(x1, y1), new Pnt(x2, y2), new Pnt(x3, y3) }; // Пример точек для треугольника
                    figure = triangleFactory.CreateFigure(pntsTriangle, color, ttl);
                    break;
            }

            // Декорирование фигуры, если isDecorated равно true
            if (isDecorated)
            {
                // Пример создания декоратора для круга
                if (figure is Circle circle)
                {
                    figure = new CircleDecorator(circle , circle.Color);
                }
                // Пример создания декоратора для прямоугольника
                else if (figure is Rectangle rectangle)
                {
                    figure = new RectangleDecorator(rectangle , rectangle.Color);
                }
                // Пример создания декоратора для квадрата
                else if (figure is Square square)
                {
                    figure = new SquareDecorator(square , square.Color);
                }
                // Пример создания декоратора для треугольника
                else if (figure is Triangle triangle)
                {
                    figure = new TriangleDecorator(triangle , triangle.Color);
                }
            }

            return figure;
        }
    }
}
