using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public class Pound
    {
        private readonly BigInteger[] fishes = new BigInteger[9];

        public Pound(string input)
        {
            foreach (var number in input.Split(',').Select(int.Parse))
            {
                fishes[number]++;
            }
        }

        public BigInteger Count
        {
            get
            {
                BigInteger total = 0;
                foreach (BigInteger n in fishes)
                    total += n;
                return total;
            }
        }

        public void Iterate()
        {
            BigInteger newFish = fishes[0];
            fishes[0] = fishes[1];
            fishes[1] = fishes[2];
            fishes[2] = fishes[3];
            fishes[3] = fishes[4];
            fishes[4] = fishes[5];
            fishes[5] = fishes[6];
            fishes[6] = fishes[7];
            fishes[7] = fishes[8];
            fishes[8] = newFish;
            fishes[6] += newFish;
        }
    }
}
