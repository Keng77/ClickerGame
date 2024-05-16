using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Класс, представляющий квадрат
    /// </summary>
    public class Square : Figure
    {
        private double _lenA;

        /// <summary>
        /// Конструктор класса Square
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих квадрат</param>
        /// <param name="color">Цвет квадрата</param>
        /// <param name="ttl">Время жизни квадрата</param>
        public Square(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
        {
            CalcLen();
        }

        private void CalcLen()
        {
            this._lenA = pnts[0].ToLen(pnts[1]);
        }

        /// <summary>
        /// Получить периметр квадрата
        /// </summary>
        /// <returns>Периметр квадрата</returns>
        public override double GetP()
        {
            return (4 * _lenA);
        }

        /// <summary>
        /// Получить площадь квадрата
        /// </summary>
        /// <returns>Площадь квадрата</returns>
        public override double GetS()
        {
            return Math.Pow(_lenA, 2);
        }

        /// <summary>
        /// Проверить, содержит ли квадрат заданную точку
        /// </summary>
        /// <param name="pnt">Точка</param>
        /// <returns>True, если квадрат содержит точку, иначе False</returns>
        public override bool IsContain(Pnt pnt)
        {
            bool isCnt = false;

            if (((pnts[0].X <= pnt.X) && (pnts[1].X >= pnt.X)) && ((pnts[0].Y <= pnt.Y) && (pnts[1].Y >= pnt.Y))) isCnt = true;

            return isCnt;
        }

        /// <summary>
        /// Получить стоимость квадрата
        /// </summary>
        /// <returns>Стоимость квадрата</returns>
        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4));
        }
    }
}