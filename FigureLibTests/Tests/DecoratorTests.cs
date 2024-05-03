using System.Drawing;
using FiguresClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class FigureDecoratorTests
    {
        [TestMethod]
        public void FigureDecorator_GetP_ReturnsDecoratedFigurePerimeter()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 5)
            };
            Color color = Color.Red;
            int ttl = 10;

            Circle circle = new Circle(pnts, color, ttl);
            FigureDecorator decorator = new FigureDecorator(circle);

            // Act
            double perimeter = decorator.GetP();

            // Assert
            double expectedPerimeter = circle.GetP();
            Assert.AreEqual(expectedPerimeter, perimeter);
        }

        [TestMethod]
        public void FigureDecorator_GetS_ReturnsDecoratedFigureArea()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 5)
            };
            Color color = Color.Red;
            int ttl = 10;

            Circle circle = new Circle(pnts, color, ttl);
            FigureDecorator decorator = new FigureDecorator(circle);

            // Act
            double area = decorator.GetS();

            // Assert
            double expectedArea = circle.GetS();
            Assert.AreEqual(expectedArea, area);
        }

        [TestMethod]
        public void FigureDecorator_IsContain_ReturnsDecoratedFigureContainmentResult()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 5)
            };
            Color color = Color.Red;
            int ttl = 10;

            Circle circle = new Circle(pnts, color, ttl);
            FigureDecorator decorator = new FigureDecorator(circle);

            Pnt insidePoint = new Pnt(2, 0);

            // Act
            bool isContain = decorator.IsContain(insidePoint);

            // Assert
            bool expectedContainment = circle.IsContain(insidePoint);
            Assert.AreEqual(expectedContainment, isContain);
        }

        [TestMethod]
        public void FigureDecorator_GetCost_ReturnsDecoratedFigureBaseCost()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 5)
            };
            Color color = Color.Red;
            int ttl = 10;

            Circle circle = new Circle(pnts, color, ttl);
            FigureDecorator decorator = new FigureDecorator(circle);

            // Act
            int Cost = decorator.GetCost();

            // Assert
            int expectedCost = decorator.GetCost();
            Assert.AreEqual(expectedCost, Cost);
        }

        [TestMethod]
        public void FigureDecorator_GetBaseCost_ReturnsDecoratedFigureBaseCost()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 5)
            };
            Color color = Color.Red;
            int ttl = 10;

            Circle circle = new Circle(pnts, color, ttl);
            FigureDecorator decorator = new FigureDecorator(circle);

            // Act
            int baseCost = decorator.GetBaseCost();

            // Assert
            int expectedBaseCost = circle.GetCost();
            Assert.AreEqual(expectedBaseCost, baseCost);
        }
    }
}