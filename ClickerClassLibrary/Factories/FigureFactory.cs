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
    /// Абстрактная фабрика для создания фигур.
    /// </summary>
    public abstract class FigureFactory
    {
        /// <summary>
        /// Создает фигуру на основе заданных параметров.
        /// </summary>
        /// <param name="pnts">Массив точек, определяющих фигуру.</param>
        /// <param name="color">Цвет фигуры.</param>
        /// <param name="ttl">Время жизни фигуры.</param>
        /// <returns>Экземпляр класса Figure или одного из его производных классов.</returns>
        public abstract Figure CreateFigure(Pnt[] pnts, Color color, int ttl);
    }
}