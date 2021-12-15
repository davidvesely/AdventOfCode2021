using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public class Pound
    {
        private readonly List<int> fishes = new(6000);

        private static readonly object locking = new ();

        public Pound(string input)
        {
            fishes.AddRange(input.Split(',').Select(int.Parse));
        }

        public int Count => fishes.Count;

        public void Iterate()
        {
            var zeroCounter = 0;

            Parallel.For(0, fishes.Count, i =>
            {
                if (fishes[i] > 0)
                    fishes[i]--;
                else
                {
                    fishes[i] = 6;
                    lock (locking)
                    {
                        zeroCounter++;
                    }
                }
            });

            // Add the new fishes with 8
            fishes.AddRange(Enumerable.Repeat(8, zeroCounter).ToArray());
        }

        public void Print()
        {
            Console.Write(string.Join(',', fishes));
        }
    }
}
