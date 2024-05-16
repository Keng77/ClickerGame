using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Базовый класс для фигур
    /// </summary>
    public abstract class Figure
    {
        public Pnt[] pnts = null;
        public Color Color { get; private set; } //свойство - цвет фигуры
        public int TTL; //time to live

        /// <summary>
        /// Конструктор класса Figure
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих фигуру</param>
        public Figure(Pnt[] pnts)
        {
            this.pnts = pnts;
        }

        /// <summary>
        /// Конструктор класса Figure
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих фигуру</param>
        /// <param name="color">Цвет фигуры</param>
        /// <param name="ttl">Время жизни фигуры</param>
        public Figure(Pnt[] pnts, Color color, int ttl)
        {
            this.pnts = pnts;
            this.Color = color;
            TTL = ttl;
        }

        /// <summary>
        /// Получить периметр фигуры
        /// </summary>
        /// <returns>Периметр фигуры</returns>
        public abstract double GetP();

        /// <summary>
        /// Получить площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        public abstract double GetS();

        /// <summary>
        /// Проверить, содержит ли фигура заданную точку
        /// </summary>
        /// <param name="pnt">Точка</param>
        /// <returns>True, если фигура содержит точку, иначе False</returns>
        public abstract bool IsContain(Pnt pnt);

        /// <summary>
        /// Получить стоимость фигуры
        /// </summary>
        /// <returns>Стоимость фигуры</returns>
        public abstract int GetCost();

        /// <summary>
        /// Уменьшить время жизни фигуры на 1
        /// </summary>
        public void DecTTL()
        {
            TTL--;
        }

        /// <summary>
        /// Проверить, существует ли фигура
        /// </summary>
        /// <returns>True, если фигура существует, иначе False</returns>
        public bool IsAlive()
        {
            if (TTL > 0)
            {
                return true;
            }
            return false;
        }
    }
}