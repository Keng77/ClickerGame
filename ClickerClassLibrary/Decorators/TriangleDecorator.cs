using System.Drawing;

namespace FiguresClassLibrary
{
    public class TriangleDecorator : FigureDecorator
    {
        public TriangleDecorator(Figure figure)
            : base(figure)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}