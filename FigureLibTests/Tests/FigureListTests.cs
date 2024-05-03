using FiguresClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class FiguresListTests
    {
        [TestMethod]
        public void AddFigure_IncreasesFiguresCount()
        {
            // Arrange
            FiguresList figuresList = new FiguresList();
            Figure figure = new Circle(new Pnt[] { new Pnt(0, 0), new Pnt(10, 10) }, Color.Red, 5);
            int initialCount = figuresList.Figures.Count;
            int expectedCount = initialCount + 1;

            // Act
            figuresList.AddFigure(figure);
            int actualCount = figuresList.Figures.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void RemoveFigure_DecreasesFiguresCount()
        {
            // Arrange
            FiguresList figuresList = new FiguresList();
            Figure figure = new Circle(new Pnt[] { new Pnt(0, 0), new Pnt(10, 10) }, Color.Red, 5);
            figuresList.AddFigure(figure);
            int initialCount = figuresList.Figures.Count;
            int expectedCount = initialCount - 1;

            // Act
            figuresList.RemoveFigure(figure);
            int actualCount = figuresList.Figures.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void RemoveFigure_UsingQueue_DecreasesFiguresCount()
        {
            // Arrange
            FiguresList figuresList = new FiguresList();
            Figure figure1 = new Circle(new Pnt[] { new Pnt(0, 0), new Pnt(10, 10) }, Color.Red, 5);
            Figure figure2 = new FiguresClassLibrary.Rectangle(new Pnt[] { new Pnt(0, 0), new Pnt(10, 10) }, Color.Blue, 5);
            figuresList.AddFigure(figure1);
            figuresList.AddFigure(figure2);
            Queue<Figure> removalQueue = new Queue<Figure>();
            removalQueue.Enqueue(figure1);
            removalQueue.Enqueue(figure2);
            int initialCount = figuresList.Figures.Count;
            int expectedCount = initialCount - removalQueue.Count;

            // Act
            figuresList.RemoveFigure(removalQueue);
            int actualCount = figuresList.Figures.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void DecTTL_DecreasesTTLForAllFigures()
        {
            // Arrange
            FiguresList figuresList = new FiguresList();
            Figure figure1 = new Circle(new Pnt[] { new Pnt(0, 0), new Pnt(10, 10) }, Color.Red, 5);
            Figure figure2 = new FiguresClassLibrary.Rectangle(new Pnt[] { new Pnt(0, 0), new Pnt(10, 10) }, Color.Blue, 5);
            figuresList.AddFigure(figure1);
            figuresList.AddFigure(figure2);

            // Act
            figuresList.DecTTL();

            // Assert
            Assert.AreEqual(4, figure1.TTL);
            Assert.AreEqual(4, figure2.TTL);
        }
        

        [TestMethod]
        public void GetRndFigure_ReturnsValidFigure()
        {
            // Arrange
            FiguresList figuresList = new FiguresList();
            int width = 1920;
            int height = 1080;

            // Act
            Figure figure = figuresList.GetRndFigure(width, height);

            // Assert
            Assert.IsNotNull(figure);
            Assert.IsTrue(figure is Figure);
            Assert.IsTrue(figure.TTL >= 3 && figure.TTL <= 10);
        }
    }
}