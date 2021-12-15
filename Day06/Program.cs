using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day06
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var input = "3,4,1,1,5,1,3,1,1,3,5,1,1,5,3,2,4,2,2,2,1,1,1,1,5,1,1,1,1,1,3,1,1,5,4,1,1,1,4,1,1,1,1,2,3,2,5,1,5,1,2,1,1,1,4,1,1,1,1,3,1,1,3,1,1,1,1,1,1,2,3,4,2,1,3,1,1,2,1,1,2,1,5,2,1,1,1,1,1,1,4,1,1,1,1,5,1,4,1,1,1,3,3,1,3,1,3,1,4,1,1,1,1,1,4,5,1,1,3,2,2,5,5,4,3,1,2,1,1,1,4,1,3,4,1,1,1,1,2,1,1,3,2,1,1,1,1,1,4,1,1,1,4,4,5,2,1,1,1,1,1,2,4,2,1,1,1,2,1,1,2,1,5,1,5,2,5,5,1,1,3,1,4,1,1,1,1,1,1,1,4,1,1,4,1,1,1,1,1,2,1,2,1,1,1,5,1,1,3,5,1,1,5,5,3,5,3,4,1,1,1,3,1,1,3,1,1,1,1,1,1,5,1,3,1,5,1,1,4,1,3,1,1,1,2,1,1,1,2,1,5,1,1,1,1,4,1,3,2,3,4,1,3,5,3,4,1,4,4,4,1,3,2,4,1,4,1,1,2,1,3,1,5,5,1,5,1,1,1,5,2,1,2,3,1,4,3,3,4,3";
        //    var pound = new Pound(input);

        //    for (int i = 0; i < 256; i++)
        //    {
        //        Console.WriteLine($"Day {i + 1,2}");
        //        pound.Iterate();
        //    }

        //    Console.WriteLine(pound.Count);
        //}

        static void Main()
        {
            List<string>? data = null;
            using (var sr = new StreamReader(@"input.txt"))
                data = sr.ReadToEnd().Split($"\n", StringSplitOptions.RemoveEmptyEntries).ToList();

            long[] numbers = data[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            BigInteger[] fishdata = new BigInteger[9];

            foreach (int n in numbers)
                fishdata[n]++;

            int total_days = 256;

            for (int n = 0; n < total_days; n++)
            {
                BigInteger newfish = fishdata[0];
                fishdata[0] = fishdata[1];
                fishdata[1] = fishdata[2];
                fishdata[2] = fishdata[3];
                fishdata[3] = fishdata[4];
                fishdata[4] = fishdata[5];
                fishdata[5] = fishdata[6];
                fishdata[6] = fishdata[7];
                fishdata[7] = fishdata[8];
                fishdata[8] = newfish;
                fishdata[6] += newfish;
            }

            BigInteger total = 0;

            foreach (BigInteger n in fishdata)
                total += n;

            Console.WriteLine(total);
        }
    }
}
