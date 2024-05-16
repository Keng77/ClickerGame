using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Класс, представляющий прямоугольник
    /// </summary>
    public class Rectangle : Figure
    {
        private double _lenA;
        private double _lenB;

        /// <summary>
        /// Конструктор класса Rectangle
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих прямоугольник</param>
        /// <param name="color">Цвет прямоугольника</param>
        /// <param name="ttl">Время жизни прямоугольника</param>
        public Rectangle(Pnt[] pnts, Color color, int ttl) : base(pnts, color, ttl)
        {
            CalcLen();
        }

        private void CalcLen()
        {
            Pnt upRight = new Pnt(pnts[1].X, pnts[0].Y);

            this._lenA = upRight.ToLen(pnts[0]);
            this._lenB = upRight.ToLen(pnts[1]);
        }

        /// <summary>
        /// Получить периметр прямоугольника
        /// </summary>
        /// <returns>Периметр прямоугольника</returns>
        public override double GetP()
        {
            return 2 * (_lenA + _lenB);
        }

        /// <summary>
        /// Получить площадь прямоугольника
        /// </summary>
        /// <returns>Площадь прямоугольника</returns>
        public override double GetS()
        {
            return _lenA * _lenB;
        }

        /// <summary>
        /// Проверить, содержит ли прямоугольник заданную точку
        /// </summary>
        /// <param name="pnt">Точка</param>
        /// <returns>True, если прямоугольник содержит точку, иначе False</returns>
        public override bool IsContain(Pnt pnt)
        {
            bool isCnt = false;

            if (((pnts[0].X <= pnt.X) && (pnts[1].X >= pnt.X)) && ((pnts[0].Y <= pnt.Y) && (pnts[1].Y >= pnt.Y))) isCnt = true;

            return isCnt;
        }

        /// <summary>
        /// Получить стоимость прямоугольника
        /// </summary>
        /// <returns>Стоимость прямоугольника</returns>
        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4));
        }
    }
}