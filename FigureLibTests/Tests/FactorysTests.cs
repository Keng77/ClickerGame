using System;
using System.Drawing;
using FigureClassLibrary;
using FiguresClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class FigureFactoryTests
    {
        [TestMethod]
        public void CircleFactory_CreateFigure_ReturnsCircle()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 0)
            };
            Color color = Color.Red;
            int ttl = 10;

            CircleFactory factory = new CircleFactory();

            // Act
            Figure figure = factory.CreateFigure(pnts, color, ttl);

            // Assert
            Assert.IsInstanceOfType(figure, typeof(Circle));
            Assert.AreEqual(pnts, figure.pnts);
            Assert.AreEqual(color, figure.Color);
            Assert.AreEqual(ttl, figure.TTL);
        }

        [TestMethod]
        public void RectangleFactory_CreateFigure_ReturnsRectangle()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 0)
            };
            Color color = Color.Blue;
            int ttl = 10;

            RectangleFactory factory = new RectangleFactory();

            // Act
            Figure figure = factory.CreateFigure(pnts, color, ttl);

            // Assert
            Assert.IsInstanceOfType(figure, typeof(FiguresClassLibrary.Rectangle));
            Assert.AreEqual(pnts, figure.pnts);
            Assert.AreEqual(color, figure.Color);
            Assert.AreEqual(ttl, figure.TTL);
        }

        [TestMethod]
        public void SquareFactory_CreateFigure_ReturnsSquare()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 0)
            };
            Color color = Color.Green;
            int ttl = 10;

            SquareFactory factory = new SquareFactory();

            // Act
            Figure figure = factory.CreateFigure(pnts, color, ttl);

            // Assert
            Assert.IsInstanceOfType(figure, typeof(Square));
            Assert.AreEqual(pnts, figure.pnts);
            Assert.AreEqual(color, figure.Color);
            Assert.AreEqual(ttl, figure.TTL);
        }

        [TestMethod]
        public void TriangleFactory_CreateFigure_ReturnsTriangle()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(0, 4),
                new Pnt(3, 0)
            };
            Color color = Color.Yellow;
            int ttl = 10;

            TriangleFactory factory = new TriangleFactory();

            // Act
            Figure figure = factory.CreateFigure(pnts, color, ttl);

            // Assert
            Assert.IsInstanceOfType(figure, typeof(Triangle));
            Assert.AreEqual(pnts, figure.pnts);
            Assert.AreEqual(color, figure.Color);
            Assert.AreEqual(ttl, figure.TTL);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleFactory_CreateFigure_ThrowsArgumentExceptionForInvalidPointCount()
        {
            // Arrange
            Pnt[] pnts = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(5, 0),
                new Pnt(10, 0)
            };
            Color color = Color.Red;
            int ttl = 10;

            CircleFactory factory = new CircleFactory();

            // Act
            Figure figure = factory.CreateFigure(pnts, color, ttl);

            // Assert
            // ArgumentException should be thrown
        }
    }
}