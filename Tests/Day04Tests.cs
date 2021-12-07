using System.Text.RegularExpressions;
using Day04;
using NUnit.Framework;

namespace Tests
{
    public class Day04Tests
    {
        [Test]
        public void BoardWinner()
        {
            var board = new Board(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            });

            Assert.That(board.MarkNumber(1), Is.False);
            Assert.That(board.MarkNumber(5), Is.False);
            Assert.That(board.MarkNumber(9), Is.False);
            Assert.That(board.MarkNumber(3), Is.False);
            Assert.That(board.MarkNumber(2), Is.True);

            Assert.That(board.SumUnmarked, Is.EqualTo(25));
        }

        [Test]
        public void FirstTaskTest()
        {
            var lines = Regex.Split(Stubs.Day04TestInput, "\r\n|\r|\n");
            var (numbers, boards) = Program.ParseInput(lines);
            int actual = Program.RunFirstTask(numbers, boards);

            Assert.That(actual, Is.EqualTo(4512));
        }
    }
}
