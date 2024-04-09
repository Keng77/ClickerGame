using System.Drawing;

namespace FiguresClassLibrary
{
    public class SquareDecorator : FigureDecorator
    {
        public SquareDecorator(Figure figure, Color penaltyColor)
            : base(figure, penaltyColor)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}