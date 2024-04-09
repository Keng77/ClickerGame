using System.Drawing;

namespace FiguresClassLibrary
{
    public class CircleDecorator : FigureDecorator
    {
        public CircleDecorator(Figure figure)
            : base(figure)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}