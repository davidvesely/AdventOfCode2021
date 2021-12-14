using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public record Point(int X, int Y)
    {
        public static Point FromString(string input)
        {
            var pointRaw = input.Split(",");
            return new Point(
                int.Parse(pointRaw[0]),
                int.Parse(pointRaw[1])
            );
        }
    }
}
