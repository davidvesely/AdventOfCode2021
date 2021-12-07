using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day03
{
    // Bits position are counted from the left starting with 0 index
    public static class Program
    {
        private static (List<int>, int) ReadInput()
        {
            var binaryNumbers = File.ReadAllLines("input.txt");
            return (
                binaryNumbers.Select(n => Convert.ToInt32(n, 2)).ToList(),
                binaryNumbers.First().Length);
        }

        public static int GetBit(this int input, int bitNumber)
        {
            return (input & (1 << bitNumber)) != 0 ? 1 : 0;
        }

        public static int SetBit(this int input, int bitNumber, int bitValue)
        {
            if (bitValue is not 0 and not 1)
                throw new ArgumentException();

            if (bitValue == 1)
            {
                //left-shift 1, then bitwise OR
                return input | (1 << bitNumber);
            }
            else
            {
                //left-shift 1, then take complement, then bitwise AND
                return input & ~(1 << bitNumber);
            }
        }

        public static int RunFirstTask(List<int> numbers, int numberLength)
        {
            int mostCommonInt = 0, leastCommonInt = 0;

            for (int i = 0; i < numberLength; i++)
            {
                int bitZeroCount = 0, bitOneCount = 0;
                foreach (var number in numbers)
                {
                    var bit = GetBit(number, i);
                    if (bit == 0)
                        bitZeroCount++;
                    else
                        bitOneCount++;
                }

                if (bitZeroCount > bitOneCount)
                {
                    mostCommonInt = mostCommonInt.SetBit(i, 0);
                    leastCommonInt = leastCommonInt.SetBit(i, 1);
                }
                else
                {
                    mostCommonInt = mostCommonInt.SetBit(i, 1);
                    leastCommonInt = leastCommonInt.SetBit(i, 0);
                }
            }

            return mostCommonInt * leastCommonInt;
        }

        public static int RunSecondTask(List<int> numbers, int numberLength)
        {
            int oxygen = FilterValues(numbers, numberLength - 1, MostCommon).Single();
            int co2 = FilterValues(numbers, numberLength - 1, LeastCommon).Single();
            return oxygen * co2;
        }

        private static List<int> MostCommon(List<int> zeroes, List<int> ones)
        {
            return zeroes.Count() > ones.Count() ? zeroes : ones;
        }

        private static List<int> LeastCommon(List<int> zeroes, List<int> ones)
        {
            return zeroes.Count() > ones.Count() ? ones : zeroes;
        }

        private static List<int> FilterValues(List<int> input, int bit,
            Func<List<int>, List<int>, List<int>> criteria)
        {
            if (input.Count() == 1)
                return input;

            var zeroes = input.Where(num => num.GetBit(bit) == 0).ToList();
            var ones = input.Where(num => num.GetBit(bit) == 1).ToList();

            var filtered = criteria(zeroes, ones);

            if (filtered.Count() > 1)
            {
                if (bit > 0)
                    return FilterValues(filtered, --bit, criteria);
                else
                    throw new Exception($"Bit positions exceeded, remaining values: {string.Join(", ", filtered)}");
            }

            return filtered;
        }

        static void Main()
        {
            var (numbers, numberLength) = ReadInput();
            Console.WriteLine("Running first task");
            var powerConsumption = RunFirstTask(numbers, numberLength);
            Console.WriteLine($"Power consumption of the submarine: {powerConsumption}");
            Console.WriteLine();
            Console.WriteLine("Running second task");
            var lifeSupportRating = RunSecondTask(numbers, numberLength);
            Console.WriteLine($"Life support rating: {lifeSupportRating}");
        }
    }
}
