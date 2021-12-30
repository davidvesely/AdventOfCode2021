using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public static class Extensions
    {
        public static HashSet<char> ToSignalPattern(this string input)
        {
            return new HashSet<char>(input.ToCharArray());
        }
    }
}
