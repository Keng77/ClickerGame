using FigureClassLibrary;
using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Фабрика для создания прямоугольников.
    /// </summary>
    public class RectangleFactory : FigureFactory
    {
        /// <summary>
        /// Создает экземпляр прямоугольника на основе заданных точек, цвета и времени жизни.
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих прямоугольник.</param>
        /// <param name="color">Цвет прямоугольника.</param>
        /// <param name="ttl">Время жизни прямоугольника.</param>
        /// <returns>Экземпляр прямоугольника.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество точек не равно 2.</exception>
        public override Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 2)
            {
                throw new ArgumentException("Количество точек должно быть = 2.");
            }

            return new Rectangle(pnts, color, ttl);
        }
    }
}