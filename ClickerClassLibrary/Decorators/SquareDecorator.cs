using System.Drawing;

namespace FiguresClassLibrary
{
    public class SquareDecorator : FigureDecorator
    {
        public SquareDecorator(Figure figure)
            : base(figure)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}