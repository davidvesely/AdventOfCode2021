using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class OceanFloor
    {
        private int[,] board;

        public OceanFloor()
        {
            board = Initialize(5, 5);
        }

        public int GetPoint(int x, int y) => board[x, y];

        public void AddLines(List<Vector> input, bool straightOnly)
        {
            foreach (var vector in input)
            {
                // Resize the board
                var maxX = Math.Max(vector.Start.X, vector.End.X);
                var maxY = Math.Max(vector.Start.Y, vector.End.Y);
                if (board.GetLength(0) < maxX + 1
                    || board.GetLength(1) < maxY + 1)
                {
                    board = Resize(board,
                        Math.Max(board.GetLength(0), maxX + 1),
                        Math.Max(board.GetLength(1), maxY + 1));
                }

                if (vector.IsStraight)
                {
                    AddStraightVector(vector);
                }
                else if (vector.IsDiagonal && !straightOnly)
                {
                    AddDiagonalVector(vector);
                }

                //PrintBoard();
            }
        }

        public void AddStraightVector(Vector vector)
        {
            var (start, end) = vector;
            if (start.X == end.X)
            {
                var x = start.X;
                for (int y = Math.Min(start.Y, end.Y); y <= Math.Max(start.Y, end.Y); y++)
                {
                    board[x, y]++;
                }
            }
            else if (start.Y == end.Y)
            {
                var y = start.Y;
                for (int x = Math.Min(start.X, end.X); x <= Math.Max(start.X, end.X); x++)
                {
                    board[x, y]++;
                }
            }
        }

        public void AddDiagonalVector(Vector vector)
        {
            var (start, end) = vector;
            if (vector.IsDiagonalCross)
            {
                int i = Math.Min(start.X, end.X);
                int j = Math.Max(start.Y, end.Y);
                for (; i <= Math.Max(start.X, end.X); i++, j--)
                {
                    board[i, j]++;
                }
            }
            else if (vector.IsDiagonalParallel)
            {
                var diff = start.Y - start.X;
                for (int i = Math.Min(start.X, end.X); i <= Math.Max(start.X, end.X); i++)
                {
                    board[i, i + diff]++;
                }
            }
        }

        public int DangerousPointsCount
        {
            get
            {
                int counter = 0;
                for (int i = 0; i < board.GetLength(0); i++)
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] > 1)
                        {
                            counter++;
                        }
                    }

                return counter;
            }
        }

        public void PrintBoard()
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    var value = board[i, j];
                    if (value > 0)
                        Console.Write(value);
                    else
                        Console.Write('.');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static int[,] Initialize(int x, int y)
        {
            var board = new int[x, y];
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = 0;
            return board;
        }

        private static int[,] Resize(int[,] board, int newMaxX, int newMaxY)
        {
            int[,] newBoard = Initialize(newMaxX, newMaxY);
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    newBoard[i, j] = board[i, j];
            return newBoard;
        }
    }
}
