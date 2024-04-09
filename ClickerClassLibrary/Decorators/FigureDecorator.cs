using System.Drawing;

namespace FiguresClassLibrary
{
    // Абстрактный декоратор фигур
    public abstract class FigureDecorator : Figure
    {
        protected Figure decoratedFigure;
        protected Color penaltyColor;

        public FigureDecorator(Figure figure, Color penaltyColor)
           : base(figure.pnts, figure.Color, figure.TTL)
        {
            this.decoratedFigure = figure;
            this.penaltyColor = penaltyColor;
        }

        public override double GetP()
        {
            return decoratedFigure.GetP();
        }

        public override double GetS()
        {
            return decoratedFigure.GetS();
        }

        public override bool IsContain(Pnt pnt)
        {
            return decoratedFigure.IsContain(pnt);
        }

        public override int GetCost()
        {
            if(penaltyColor == decoratedFigure.Color)
            {
                return (int)((1000 / GetS()) + (TTL * 5 / 4) - 25);
            }
            return decoratedFigure.GetCost();
        }
    }
}