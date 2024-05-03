using FiguresClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void ToLen_ReturnsCorrectDistance()
        {
            // Arrange
            Pnt pnt1 = new Pnt(0, 0);
            Pnt pnt2 = new Pnt(3, 4);
            double expectedDistance = 5;

            // Act
            double actualDistance = pnt1.ToLen(pnt2);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance, 0.001);
        }

        [TestMethod]
        public void ToLen_ReturnsZeroForSamePoint()
        {
            // Arrange
            Pnt pnt1 = new Pnt(2, 3);
            Pnt pnt2 = new Pnt(2, 3);
            double expectedDistance = 0;

            // Act
            double actualDistance = pnt1.ToLen(pnt2);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance, 0.001);
        }

        [TestMethod]
        public void ToLen_ReturnsCorrectDistanceForDifferentPoints()
        {
            // Arrange
            Pnt pnt1 = new Pnt(1, 2);
            double x = 4;
            double y = 6;
            double expectedDistance = 5;

            // Act
            double actualDistance = pnt1.ToLen(x, y);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance, 0.001);
        }
    }
}