using System;
using System.Linq;
using NUnit.Framework;
using Tests;

namespace Day03
{
    public class Day03Tests
    {
        [Test]
        public void GetBit()
        {
            // Arrange
            var aRaw = "100101";
            var a = Convert.ToInt32(aRaw, 2);

            // Assert
            Assert.That(Program.GetBit(a, 0), Is.EqualTo(1), "First bit");
            Assert.That(Program.GetBit(a, 1), Is.EqualTo(0), "Second bit");
            Assert.That(Program.GetBit(a, 2), Is.EqualTo(1), "Third bit");
            Assert.That(Program.GetBit(a, 3), Is.EqualTo(0), "Fourth bit");
            Assert.That(Program.GetBit(a, 4), Is.EqualTo(0), "Fifth bit");
            Assert.That(Program.GetBit(a, 5), Is.EqualTo(1), "Sixth bit");
        }

        [Test]
        [TestCase("010010", 0, 1, 19)]
        [TestCase("010011", 1, 0, 17)]
        public void SetBit(string input, int bitPosition, int bitValue, int expected)
        {
            var number = Convert.ToInt32(input, 2);
            var actual = number.SetBit(bitPosition, bitValue);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstTask()
        {
            var parsedInput = Stubs.Day03TestInput.Select(a => Convert.ToInt32(a, 2)).ToList();
            var powerConsumption = Program.RunFirstTask(parsedInput, 5);
            Assert.That(powerConsumption, Is.EqualTo(198));
        }

        [Test]
        public void SecondTask()
        {
            var parsedInput = Stubs.Day03TestInput.Select(a => Convert.ToInt32(a, 2)).ToList();
            var lifeSupportingRating = Program.RunSecondTask(parsedInput, 5);
            Assert.That(lifeSupportingRating, Is.EqualTo(230));
        }
    }
}
