using FigureClassLibrary;
using System;
using System.Drawing;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Фабрика для создания треугольников.
    /// </summary>
    public class TriangleFactory : FigureFactory
    {
        /// <summary>
        /// Создает экземпляр треугольника на основе заданных точек, цвета и времени жизни.
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих треугольник.</param>
        /// <param name="color">Цвет треугольника.</param>
        /// <param name="ttl">Время жизни треугольника.</param>
        /// <returns>Экземпляр треугольника.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество точек не равно 3.</exception>
        public override Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 3)
            {
                throw new ArgumentException("Количество точек должно быть = 3.");
            }

            return new Triangle(pnts, color, ttl);
        }
    }
}