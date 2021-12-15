using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day06;
using NUnit.Framework;

namespace Tests
{
    public class Day06Tests
    {
        [Test]
        public void PoundTestFirstDay()
        {
            var input = "3,4,3,1,2";
            var pound = new Pound(input);

            //Console.WriteLine($"Initial state: {input}");

            for (int i = 0; i < 80; i++)
            {
                pound.Iterate();
                //Console.Write($"After {i + 1,2} days: ");
                //pound.Print();
                //Console.WriteLine();
            }

            Assert.That(pound.Count, Is.EqualTo(5934));
        }
    }
}
