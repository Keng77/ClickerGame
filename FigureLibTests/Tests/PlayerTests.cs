using FiguresClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresClassLibraryTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void AddScore_IncreasesScoreByGivenAmount()
        {
            // Arrange
            Player player = new Player("John");
            int initialScore = player.Score;
            int scoreToAdd = 10;
            int expectedScore = initialScore + scoreToAdd;

            // Act
            player.AddScore(scoreToAdd);
            int actualScore = player.Score;

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            Player player = new Player("Alice");
            player.AddScore(20);
            string expectedString = "Alice: 20";

            // Act
            string actualString = player.ToString();

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }
    }
}