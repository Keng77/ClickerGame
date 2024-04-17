using FigureClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FiguresClassLibrary
{
    public class FiguresList
    {
        private readonly Random rnd = new Random();
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

        public Figure GetRndFigure(int width, int height)
        {
            Figure figure = null;

            int typeF = rnd.Next(0, 4);

            int minSize = 50; // Минимальный размер фигуры
            int maxSize = Math.Min(width, height) / 4; // Максимальный размер фигуры

            int offset = 100; // Отступ в пикселях

            int x1 = rnd.Next(minSize + offset, width - minSize - offset);
            int y1 = rnd.Next(minSize + offset, height - minSize - offset);
            int x2 = rnd.Next(minSize + offset, width - offset);
            int y2 = rnd.Next(minSize + offset, height - minSize - offset);

            Color color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            int ttl = rnd.Next(3, 10);

            bool isDecorated = rnd.Next(1, 101) <= 20; // Шанс декорирования 20%

            switch (typeF)
            {
                case 0:
                    int radius = rnd.Next(minSize, maxSize);
                    Pnt[] circlePoints = { new Pnt(x1, y1), new Pnt(radius, radius) }; // Пример точек для круга
                    figure = circleFactory.CreateFigure(circlePoints, color, ttl);
                    break;

                case 1:
                    int widthRect = rnd.Next(minSize, maxSize);
                    int heightRect = rnd.Next(minSize, maxSize);
                    Pnt[] rectanglePoints = { new Pnt(x1, y1), new Pnt(x1 + widthRect, y1 + heightRect) }; // Пример точек для прямоугольника
                    figure = rectangleFactory.CreateFigure(rectanglePoints, color, ttl);
                    break;

                case 2:
                    int sideLength = rnd.Next(minSize, maxSize);
                    Pnt[] squarePoints = { new Pnt(x1, y1), new Pnt(x1 + sideLength, y1 + sideLength) }; // Пример точек для квадрата
                    figure = squareFactory.CreateFigure(squarePoints, color, ttl);
                    break;

                case 3:
                    int x3 = rnd.Next(minSize, width - minSize);
                    int y3 = rnd.Next(minSize + offset, height - minSize - offset);
                    Pnt[] trianglePoints = { new Pnt(x1, y1), new Pnt(x2, y2), new Pnt(x3, y3) }; // Пример точек для треугольника
                    figure = triangleFactory.CreateFigure(trianglePoints, color, ttl);
                    break;
            }

            // Декорирование фигуры, если isDecorated равно true
            if (isDecorated)
            {
                // Пример создания декоратора для круга
                if (figure is Circle circle)
                {
                    figure = new CircleDecorator(circle);
                }
                // Пример создания декоратора для прямоугольника
                else if (figure is Rectangle rectangle)
                {
                    figure = new RectangleDecorator(rectangle);
                }
                // Пример создания декоратора для квадрата
                else if (figure is Square square)
                {
                    figure = new SquareDecorator(square);
                }
                // Пример создания декоратора для треугольника
                else if (figure is Triangle triangle)
                {
                    figure = new TriangleDecorator(triangle);
                }
            }

            return figure;
        }
    }
}
