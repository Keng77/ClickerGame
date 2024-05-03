using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresClassLibrary;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class FigureDrawTests
    {
        [TestMethod]
        public void Draw_Circle_DrawsCircleOnGraphics()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            Circle circle = new Circle(new Pnt[] { new Pnt(50, 50), new Pnt(25, 25) }, Color.Red, 10);

            // Act
            FigureDraw.Draw(graphics, circle);

            // Assert
            Color expectedColor = Color.FromArgb(255, Color.Red);
            Color pixelColor = bitmap.GetPixel(50, 50);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
        }

        [TestMethod]
        public void Draw_Square_DrawsSquareOnGraphics()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            Square square = new Square(new Pnt[] { new Pnt(20, 20), new Pnt(70, 70) }, Color.Blue, 10);

            // Act
            FigureDraw.Draw(graphics, square);

            // Assert
            Color expectedColor = Color.FromArgb(255, Color.Blue);
            Color pixelColor = bitmap.GetPixel(20, 20);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
            pixelColor = bitmap.GetPixel(50, 50);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
        }

        [TestMethod]
        public void Draw_Rectangle_DrawsRectangleOnGraphics()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            FiguresClassLibrary.Rectangle rectangle = new FiguresClassLibrary.Rectangle(new Pnt[] { new Pnt(20, 20), new Pnt(80, 60) }, Color.Green, 10);

            // Act
            FigureDraw.Draw(graphics, rectangle);

            // Assert
            Color expectedColor = Color.FromArgb(255, Color.Green);
            Color pixelColor = bitmap.GetPixel(20, 20);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
            pixelColor = bitmap.GetPixel(60, 40);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
        }

        [TestMethod]
        public void Draw_Triangle_DrawsTriangleOnGraphics()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            Triangle triangle = new Triangle(new Pnt[] { new Pnt(20, 20), new Pnt(50, 80), new Pnt(80, 20) }, Color.Yellow, 10);

            // Act
            FigureDraw.Draw(graphics, triangle);

            // Assert
            Color expectedColor = Color.FromArgb(255, Color.Yellow);
            Color pixelColor = bitmap.GetPixel(24, 27);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
            pixelColor = bitmap.GetPixel(40, 60);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
            pixelColor = bitmap.GetPixel(60, 25);
            Assert.IsTrue(expectedColor.Equals(pixelColor));
        }
    }
}