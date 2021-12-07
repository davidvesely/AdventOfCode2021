using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var (numbers, boards) = ParseInput(lines);
            Console.WriteLine("Running first task");
            int score = RunFirstTask(numbers, boards);
            Console.WriteLine($"Final score of the winning board: {score}");
            Console.WriteLine("Running second task");
            score = RunSecondTask(numbers, boards);
            Console.WriteLine($"Final score of the last winning board: {score}");
        }

        public static (int[], List<Board>) ParseInput(string[] lines)
        {
            var numbers = lines[0].Split(',').Select(int.Parse).ToArray();
            var boards = new List<Board>();
            
            for (var i = 2; i < lines.Length; i++)
            {
                var boardRaw = lines.Skip(i).Take(5);
                var board = boardRaw
                    .Select(a => a
                        .Split(' ')
                        .Select(b => b.Trim())
                        .Where(b => !string.IsNullOrEmpty(b))
                        .Select(int.Parse)
                        .ToArray())
                    .ToArray();
                boards.Add(new Board(board.To2D()));
                i += 5; // Go to the next board
            }

            return (numbers, boards);
        }

        public static int RunFirstTask(int[] numbers, List<Board> boards)
        {
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (board.MarkNumber(number))
                    {
                        var unmarkedSum = board.SumUnmarked;
                        return number * unmarkedSum;
                    }
                }
            }

            return 0;
        }

        public static int RunSecondTask(int[] numbers, List<Board> boards)
        {
            var lastBoard = default(Board);
            var lastWinningNumber = 0;

            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (!board.IsWinner && board.MarkNumber(number))
                    {
                        lastBoard = board;
                        lastWinningNumber = number;
                    }
                }
            }

            return (lastBoard?.SumUnmarked ?? 0) * lastWinningNumber;
        }
    }
}
