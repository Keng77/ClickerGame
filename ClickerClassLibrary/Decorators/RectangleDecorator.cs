using System.Drawing;

namespace FiguresClassLibrary
{
    public class RectangleDecorator : FigureDecorator
    {
        public RectangleDecorator(Figure figure)
            : base(figure)
        {
        }

        public override int GetCost()
        {
            return base.GetCost(); // Вернуть результат базовой реализации
        }
    }
}