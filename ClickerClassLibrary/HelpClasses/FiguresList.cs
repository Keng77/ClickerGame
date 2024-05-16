using FigureClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Класс, представляющий список фигур.
    /// </summary>
    public class FiguresList
    {
        private readonly Random rnd = new Random();
        private readonly CircleFactory circleFactory;
        private readonly RectangleFactory rectangleFactory;
        private readonly SquareFactory squareFactory;
        private readonly TriangleFactory triangleFactory;

        /// <summary>
        /// Список фигур.
        /// </summary>
        public List<Figure> Figures { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public FiguresList()
        {
            Figures = new List<Figure>();
            circleFactory = new CircleFactory();
            rectangleFactory = new RectangleFactory();
            squareFactory = new SquareFactory();
            triangleFactory = new TriangleFactory();
        }

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="figures">Список фигур.</param>
        public FiguresList(List<Figure> figures)
        {
            this.Figures = figures;
            circleFactory = new CircleFactory();
            rectangleFactory = new RectangleFactory();
            squareFactory = new SquareFactory();
            triangleFactory = new TriangleFactory();
        }

        /// <summary>
        /// Добавляет фигуру в список.
        /// </summary>
        /// <param name="figure">Фигура для добавления.</param>
        public void AddFigure(Figure figure)
        {
            Figures.Add(figure);
        }

        /// <summary>
        /// Удаляет фигуру из списка.
        /// </summary>
        /// <param name="figure">Фигура для удаления.</param>
        public void RemoveFigure(Figure figure)
        {
            Figures.Remove(figure);
        }

        /// <summary>
        /// Удаляет фигуры из списка, указанные в очереди.
        /// </summary>
        /// <param name="rFigures">Очередь фигур для удаления.</param>
        public void RemoveFigure(Queue<Figure> rFigures)
        {
            while (rFigures.Count > 0)
            {
                Figure f = rFigures.Dequeue();
                RemoveFigure(f);
            }
        }

        /// <summary>
        /// Уменьшает время жизни всех фигур в списке на единицу.
        /// </summary>
        public void DecTTL()
        {
            foreach (Figure figure in Figures)
            {
                figure.DecTTL();
            }
        }

        /// <summary>
        /// Ищет фигуру в списке по указанным координатам.
        /// </summary>
        /// <param name="pnt">Координаты точки для поиска фигуры.</param>
        /// <returns>Найденная фигура или null, если фигура не найдена.</returns>
        public Figure FindFigure(Pnt pnt)
        {
            Figure f = null;
            bool finded = false;

            for (int i = Figures.Count - 1; i >= 0 && !finded; i--)
            {
                if (Figures[i].IsContain(pnt))
                {
                    f = Figures[i];
                    finded = true;
                }
            }

            return f;
        }

        /// <summary>
        /// Возвращает очередь с мертвыми фигурами из списка.
        /// </summary>
        /// <returns>Очередь мертвых фигур.</returns>
        public Queue<Figure> GetNotAliveFigures()
        {
            Queue<Figure> dFigures = new Queue<Figure>();

            foreach (Figure f in Figures)
            {
                if (!f.IsAlive()) dFigures.Enqueue(f);
            }

            return dFigures;
        }


        /// <summary>
        /// Функция для расчета площади треугольника.
        /// </summary>
        /// <param name="points">Массив точек, представляющих вершины треугольника.</param>
        /// <returns>Площадь треугольника.</returns>
        double CalculateTriangleArea(Pnt[] points)
        {
            double area = 0.5 * Math.Abs((points[1].X - points[0].X) * (points[2].Y - points[0].Y) - (points[2].X - points[0].X) * (points[1].Y - points[0].Y));
            return area;
        }

        /// <summary>
        /// Генерирует случайную фигуру на заданной области.
        /// </summary>
        /// <param name="width">Ширина области.</param>
        /// <param name="height">Высота области.</param>
        /// <returns>Сгенерированная фигура.</returns>
        public Figure GetRndFigure(int width, int height)
        {
            Figure figure = null;

            int typeF = rnd.Next(0, 4);

            int minSize = 50; // Минимальный размер фигуры
            int maxSize = Math.Min(width, height) / 4; // Максимальный размер фигуры

            int offset = 150; // Отступ в пикселях

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
                    double minimumArea = 30.0;
                    bool isTriangleValid = false;
                    while (!isTriangleValid)
                    {
                        int x3 = rnd.Next(minSize, width - minSize);
                        int y3 = rnd.Next(minSize + offset, height - minSize - offset);
                        Pnt[] trianglePoints = { new Pnt(x1, y1), new Pnt(x2, y2), new Pnt(x3, y3) };

                        // Рассчитываем площадь треугольника
                        double area = CalculateTriangleArea(trianglePoints);

                        if (area >= minimumArea)
                        {
                            isTriangleValid = true;
                            figure = triangleFactory.CreateFigure(trianglePoints, color, ttl);
                        }
                    }
                    break;
            }

            // Декорирование фигуры, если isDecorated равно true
            if (isDecorated)
            {
                figure = new FigureDecorator(figure);
            }

            return figure;
        }
    }
}
