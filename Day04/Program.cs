using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var (numbers, boards) = ParseInput(lines);
        }

        static (int[], List<int[,]>) ParseInput(string[] lines)
        {
            var numbers = lines[0].Split(',').Select(int.Parse).ToArray();
            var boards = new List<int[,]>();
            
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
                boards.Add(board.To2D());
                i += 5; // Go to the next board
            }

            return (numbers, boards);
        }


    }
}
