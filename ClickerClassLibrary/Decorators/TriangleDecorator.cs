using System.Drawing;

namespace FiguresClassLibrary
{
    public class TriangleDecorator : FigureDecorator
    {
        public TriangleDecorator(Figure figure, Color penaltyColor)
            : base(figure, penaltyColor)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}