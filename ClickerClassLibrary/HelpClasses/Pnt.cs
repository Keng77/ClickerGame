using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Класс, представляющий точку в двумерном пространстве.
    /// </summary>
    public class Pnt
    {
        /// <summary>
        /// Координата X точки.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Координата Y точки.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса Pnt с заданными координатами X и Y.
        /// </summary>
        /// <param name="x">Координата X точки.</param>
        /// <param name="y">Координата Y точки.</param>
        public Pnt(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Вычисляет расстояние между текущей точкой и заданными координатами X и Y.
        /// </summary>
        /// <param name="x">Координата X для вычисления расстояния.</param>
        /// <param name="y">Координата Y для вычисления расстояния.</param>
        /// <returns>Расстояние между текущей точкой и заданными координатами.</returns>
        public double ToLen(double x, double y)
        {
            double len = Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2));
            return len;
        }

        /// <summary>
        /// Вычисляет расстояние между текущей точкой и заданной точкой.
        /// </summary>
        /// <param name="pnt">Точка для вычисления расстояния.</param>
        /// <returns>Расстояние между текущей точкой и заданной точкой.</returns>
        public double ToLen(Pnt pnt)
        {
            return ToLen(pnt.X, pnt.Y);
        }
    }
}