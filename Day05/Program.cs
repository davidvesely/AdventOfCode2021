using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day05
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            List<Vector> input = ParseInput(lines);
            Console.WriteLine($"Result from first task: {RunFirstTask(input)}");
            Console.WriteLine($"Result from first task: {RunSecondTask(input)}");
        }

        public static List<Vector> ParseInput(string[] lines)
            => lines.Select(Vector.FromString).ToList();

        public static int RunFirstTask(List<Vector> input)
        {
            var oceanFloor = new OceanFloor();
            oceanFloor.AddLines(input, true);
            return oceanFloor.DangerousPointsCount;
        }

        public static int RunSecondTask(List<Vector> input)
        {
            var oceanFloor = new OceanFloor();
            oceanFloor.AddLines(input, false);
            return oceanFloor.DangerousPointsCount;
        }
    }
}
