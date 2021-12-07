using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
{
    class Program
    {
        private static  IEnumerable<MovementInstruction> ParseInput()
        {
            var rawInput = File.ReadAllLines("input.txt");
            return rawInput.Select(MovementInstruction.FromString);
        }

        private static (int, int) RunFirstTask()
        {
            int horizontal = 0, depth = 0;
            var input = ParseInput();

            foreach (var instruction in input)
            {
                switch (instruction.Direction)
                {
                    case Direction.Forward:
                        horizontal += instruction.Value;
                        break;
                    case Direction.Down:
                        depth += instruction.Value;
                        break;
                    case Direction.Up:
                        depth -= instruction.Value;
                        break;
                }
            }

            return (horizontal, depth);
        }

        private static (int, int) RunSecondTask()
        {
            int horizontal = 0, depth = 0, aim = 0;
            var input = ParseInput();

            foreach (var instruction in input)
            {
                switch (instruction.Direction)
                {
                    case Direction.Forward:
                        horizontal += instruction.Value;
                        depth += aim * instruction.Value;
                        break;
                    case Direction.Down:
                        aim += instruction.Value;
                        break;
                    case Direction.Up:
                        aim -= instruction.Value;
                        break;
                }
            }

            return (horizontal, depth);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Running first task");
            var (horizontal, depth) = RunFirstTask();
            Console.WriteLine($"Horizontal position: {horizontal}, depth: {depth}, product: {horizontal * depth}");
            Console.WriteLine();
            Console.WriteLine("Running second task");
            (horizontal, depth) = RunSecondTask();
            Console.WriteLine($"Horizontal position: {horizontal}, depth: {depth}, product: {horizontal * depth}");
        }
    }
}
