using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Класс, представляющий окружность
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Получить центр окружности
        /// </summary>
        /// <returns>Центр окружности</returns>
        public Pnt GetCenter()
        {
            return pnts[0];
        }

        /// <summary>
        /// Получить радиус окружности
        /// </summary>
        /// <returns>Радиус окружности</returns>
        public double GetR()
        {
            return pnts[1].X;
        }

        /// <summary>
        /// Конструктор класса Circle
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих окружность</param>
        /// <param name="color">Цвет окружности</param>
        /// <param name="ttl">Время жизни окружности</param>
        public Circle(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
        {
        }

        /// <summary>
        /// Получить периметр окружности
        /// </summary>
        /// <returns>Периметр окружности</returns>
        public override double GetP()
        {
            return 2 * Math.PI * GetR();
        }

        /// <summary>
        /// Получить площадь окружности
        /// </summary>
        /// <returns>Площадь окружности</returns>
        public override double GetS()
        {
            return Math.PI * GetR() * GetR();
        }

        /// <summary>
        /// Проверить, содержит ли окружность заданную точку
        /// </summary>
        /// <param name="pnt">Точка</param>
        /// <returns>True, если окружность содержит точку, иначе False</returns>
        public override bool IsContain(Pnt pnt)
        {
            bool isCnt = false;

            double dist = pnt.ToLen(pnts[0]); // Расстояние между центром окружности и точкой

            if (Math.Pow(dist, 2) <= Math.Pow(GetR(), 2))
            {
                isCnt = true;
            }

            return isCnt;
        }

        /// <summary>
        /// Получить стоимость окружности
        /// </summary>
        /// <returns>Стоимость окружности</returns>
        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4));
        }
    }
}