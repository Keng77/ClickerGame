using System.Drawing;

namespace FiguresClassLibrary
{
    public class CircleDecorator : FigureDecorator
    {
        public CircleDecorator(Figure figure, Color penaltyColor)
            : base(figure, penaltyColor)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}