using System;
using System.Drawing;
using FiguresClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = FiguresClassLibrary.Rectangle;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void Circle_GetP_ReturnsCorrectPerimeter()
        {
            // Arrange
            Pnt[] radius = new Pnt[]
          {
                new Pnt(0, 0),
                new Pnt(5, 5),
          };
            Circle circle = new Circle(radius, Color.Red, 10);

            // Act
            double perimeter = circle.GetP();

            // Assert
            double expectedPerimeter = 2 * Math.PI * 5;
            Assert.AreEqual(expectedPerimeter, perimeter);
        }

        [TestMethod]
        public void Circle_GetS_ReturnsCorrectArea()
        {
            // Arrange
            Pnt[] radius = new Pnt[]
          {
                new Pnt(0, 0),
                new Pnt(5, 5),
          };
            Circle circle = new Circle(radius, Color.Red, 10);

            // Act
            double area = circle.GetS();

            // Assert
            double expectedArea = Math.PI * 5*5;
            Assert.AreEqual(expectedArea, area);
        }

        [TestMethod]
        public void Circle_IsContain_ReturnsTrueForPointInsideCircle()
        {
            // Arrange
            Pnt[] radius = new Pnt[]
           {
                new Pnt(0, 0),
                new Pnt(5, 5),
           };
            Circle circle = new Circle(radius, Color.Red, 10);
            Pnt insidePoint = new Pnt(2, 2);

            // Act
            bool isContain = circle.IsContain(insidePoint);

            // Assert
            Assert.IsTrue(isContain);
        }

        [TestMethod]
        public void Circle_IsContain_ReturnsFalseForPointOutsideCircle()
        {
            // Arrange
            Pnt[] radius = new Pnt[]
           {
                new Pnt(0, 0),
                new Pnt(5, 5),
           };
            Circle circle = new Circle(radius, Color.Red, 10);
            Pnt outsidePoint = new Pnt(10, 10);

            // Act
            bool isContain = circle.IsContain(outsidePoint);

            // Assert
            Assert.IsFalse(isContain);
        }

        // Тесты для классов Triangle, Square и Rectangle

        // Пример для класса Triangle
        [TestMethod]
        public void Triangle_GetP_ReturnsCorrectPerimeter()
        {
            // Arrange
            Pnt[] vertices = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(0, 4),
                new Pnt(3, 0)
            };
            Triangle triangle = new Triangle(vertices, Color.Red, 10);

            // Act
            double perimeter = triangle.GetP();

            // Assert
            double expectedPerimeter = 12;
            Assert.AreEqual(expectedPerimeter, perimeter);
        }

        // Пример для класса Square
        [TestMethod]
        public void Square_GetP_ReturnsCorrectPerimeter()
        {
            // Arrange
            Pnt[] sideLength = new Pnt[]
            {
                new Pnt(0, 0),
                new Pnt(4, 0),
                
            };
            Square square = new Square(sideLength, Color.Red, 10);

            // Act
            double perimeter = square.GetP();
            double lenght = sideLength.Length;
            // Assert
            double expectedPerimeter = 4 * 4;
            Assert.AreEqual(expectedPerimeter, perimeter);
        }

        // Пример для класса Rectangle
        [TestMethod]
        public void Rectangle_GetS_ReturnsCorrectArea()
        {
            // Arrange
            Pnt[] sideLength = new Pnt[]
           {
                new Pnt(0, 0),
                new Pnt(4, 4),

           };
            Rectangle rectangle = new Rectangle(sideLength, Color.Red, 10);

            // Act
            double area = rectangle.GetS();
            double width =4;
            double height = 4;
            // Assert
            double expectedArea = width * height;
            Assert.AreEqual(expectedArea, area);
        }
    }
}