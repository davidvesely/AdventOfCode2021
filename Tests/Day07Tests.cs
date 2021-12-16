using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day07;

namespace Tests
{
    public class Day07Tests
    {
        [Test]
        public void FirstTask()
        {
            var crabs = new CrabSubmarines("16,1,2,0,4,2,7,1,2,14");
            crabs.CalculateLinearFuelCost();
            Assert.That(crabs.LeastFuel, Is.EqualTo(37));
        }

        [Test]
        public void SecondTask()
        {
            var crabs = new CrabSubmarines("16,1,2,0,4,2,7,1,2,14");
            crabs.CalculateArithmeticProgressionFuelCost();
            Assert.That(crabs.LeastFuel, Is.EqualTo(168));
        }
    }
}
