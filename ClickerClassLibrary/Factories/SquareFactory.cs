using FigureClassLibrary;
using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Фабрика для создания квадратов.
    /// </summary>
    public class SquareFactory : FigureFactory
    {
        /// <summary>
        /// Создает экземпляр квадрата на основе заданных точек, цвета и времени жизни.
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих квадрат.</param>
        /// <param name="color">Цвет квадрата.</param>
        /// <param name="ttl">Время жизни квадрата.</param>
        /// <returns>Экземпляр квадрата.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество точек не равно 2.</exception>
        public override Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 2)
            {
                throw new ArgumentException("Количество точек должно быть = 2.");
            }

            return new Square(pnts, color, ttl);
        }
    }
}