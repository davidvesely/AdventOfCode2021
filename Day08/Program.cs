using System;
using System.IO;
using System.Linq;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var outputValues = input
                .Select(a => a.Split("|")[1].Trim())
                .SelectMany(a => a.Split(" "));
            var count = outputValues.Count(a => a.Length is 2 or 3 or 4 or 7);
            Console.WriteLine("Running task one: {0}", count);

            Console.WriteLine("Running task two");
            RunTaskTwo(input);
        }

        private static void RunTaskTwo(string[] input)
        {
            int sum = 0;

            foreach (var line in input)
            {
                var display = new Display(line);
                sum += display.Calculate();
            }

            Console.WriteLine($"The sum is {sum}");
        }
    }
}
