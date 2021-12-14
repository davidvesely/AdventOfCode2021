using System.Text.RegularExpressions;
using Day05;
using NUnit.Framework;

namespace Tests
{
    public class Day05Tests
    {
        [Test]
        public void GivenOceanFloor_WhenAddLargerVector_ThenResizeTheBoard()
        {
            // Arrange
            var oceanFloor = new OceanFloor();
            oceanFloor.AddStraightVector(new Vector(new Point(1, 1), new Point(1, 2)));

            // Act
            oceanFloor.AddStraightVector(new Vector(new Point(1, 1), new Point(1, 5)));

            // Assert
            Assert.That(oceanFloor.GetPoint(1, 1), Is.EqualTo(2));
            Assert.That(oceanFloor.GetPoint(1, 5), Is.EqualTo(1));
        }

        [Test]
        public void FirstTaskTest()
        {
            var lines = Regex.Split(Stubs.Day05TestInput, "\r\n|\r|\n");
            var vectors = Program.ParseInput(lines);
            int actual = Program.RunFirstTask(vectors);

            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void SecondTaskTest()
        {
            var lines = Regex.Split(Stubs.Day05TestInput, "\r\n|\r|\n");
            var vectors = Program.ParseInput(lines);
            int actual = Program.RunSecondTask(vectors);

            Assert.That(actual, Is.EqualTo(12));
        }
    }
}
