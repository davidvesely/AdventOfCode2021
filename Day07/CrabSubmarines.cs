using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public class CrabSubmarines
    {
        private readonly List<int> positions;

        private readonly Dictionary<int, long> fuelCost;

        public CrabSubmarines(string input)
        {
            positions = input.Split(',').Select(int.Parse).ToList();
            //fuelCost = positions.Distinct().ToDictionary(a => a, _ => 0L);
            var maxPosition = positions.Max();
            fuelCost = Enumerable.Repeat(0, maxPosition + 1)
                .Select((_, index) => index)
                .ToDictionary(a => a, _ => 0L);
        }

        public void CalculateLinearFuelCost()
        {
            foreach (var position in fuelCost.Keys)
            {
                long sum = 0;
                foreach (var currentPosition in positions)
                {
                    sum += Math.Abs(position - currentPosition);
                }

                fuelCost[position] = sum;
            }
        }

        public void CalculateArithmeticProgressionFuelCost()
        {
            foreach (var position in fuelCost.Keys)
            {
                long sum = 0;
                foreach (var currentPosition in positions)
                {
                    int step = 1;
                    for (int i = Math.Min(position, currentPosition); i < Math.Max(position, currentPosition); i++)
                    {
                        sum += step;
                        step++;
                    }
                }

                fuelCost[position] = sum;
            }
        }

        public long LeastFuel => fuelCost.Min(a => a.Value);
    }
}
