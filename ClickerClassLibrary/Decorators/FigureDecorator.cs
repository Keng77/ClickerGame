using System.Drawing;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Декоратор фигур.
    /// </summary>
    public class FigureDecorator : Figure
    {
        /// <summary>
        /// Декорируемая фигура.
        /// </summary>
        public Figure decoratedFigure;

        /// <summary>
        /// Цвет штрафа.
        /// </summary>
        protected Color penaltyColor;

        /// <summary>
        /// Конструктор класса FigureDecorator.
        /// </summary>
        /// <param name="figure">Декорируемая фигура.</param>
        public FigureDecorator(Figure figure)
            : base(figure.pnts, figure.Color, figure.TTL)
        {
            this.decoratedFigure = figure;
            this.penaltyColor = figure.Color;
        }

        /// <summary>
        /// Получить периметр декорированной фигуры.
        /// </summary>
        /// <returns>Периметр декорированной фигуры.</returns>
        public override double GetP()
        {
            return decoratedFigure.GetP();
        }

        /// <summary>
        /// Получить площадь декорированной фигуры.
        /// </summary>
        /// <returns>Площадь декорированной фигуры.</returns>
        public override double GetS()
        {
            return decoratedFigure.GetS();
        }

        /// <summary>
        /// Проверить, содержит ли декорированная фигура заданную точку.
        /// </summary>
        /// <param name="pnt">Точка.</param>
        /// <returns>True, если декорированная фигура содержит точку, иначе False.</returns>
        public override bool IsContain(Pnt pnt)
        {
            return decoratedFigure.IsContain(pnt);
        }

        /// <summary>
        /// Получить стоимость декорированной фигуры.
        /// </summary>
        /// <returns>Стоимость декорированной фигуры.</returns>
        public override int GetCost()
        {
            return (int)((1000 / GetS()) + (TTL * 5 / 4) - 25);
        }

        /// <summary>
        /// Получить базовую стоимость фигуры.
        /// </summary>
        /// <returns>Базовая стоимость фигуры.</returns>
        public int GetBaseCost()
        {
            return decoratedFigure.GetCost();
        }
    }
}