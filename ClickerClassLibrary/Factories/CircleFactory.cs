using FiguresClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary
{
    /// <summary>
    /// Фабрика для создания объектов типа Circle.
    /// </summary>
    public class CircleFactory : FigureFactory
    {
        /// <summary>
        /// Создает объект типа Circle на основе заданных параметров.
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих окружность (должно быть 2 точки).</param>
        /// <param name="color">Цвет окружности.</param>
        /// <param name="ttl">Время жизни окружности.</param>
        /// <returns>Экземпляр класса Circle.</returns>
        public override Figure CreateFigure(Pnt[] pnts, Color color, int ttl)
        {
            if (pnts.Length != 2)
            {
                throw new ArgumentException("Количество точек должно быть равно 2.");
            }

            return new Circle(pnts, color, ttl);
        }
    }
}