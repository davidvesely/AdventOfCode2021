using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public record Vector(Point Start, Point End)
    {
        public static Vector FromString(string input)
        {
            var vectorsRaw = input.Split(" -> ");
            return new Vector(
                Point.FromString(vectorsRaw[0]),
                Point.FromString(vectorsRaw[1])
            );
        }

        public bool IsStraight => Start.X == End.X || Start.Y == End.Y;

        public bool IsDiagonalCross => Start.X - End.X == End.Y - Start.Y;

        public bool IsDiagonalParallel => Start.X - End.X == Start.Y - End.Y;

        public bool IsDiagonal => IsDiagonalCross || IsDiagonalParallel;
    }
}
