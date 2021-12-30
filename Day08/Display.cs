using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    public class Display
    {
        private HashSet<char>[] digits;
        private List<string> digitsRaw;
        private List<string> output;

        public Display(string input)
        {
            digits = new HashSet<char>[10];
            ParseInput(input);
            ProcessDigits();
        }

        public int Calculate()
        {
            string outputValue = string.Empty;
            foreach (var number in output)
            {
                var seq = number.ToSignalPattern();
                for (int i = 0; i < digits.Length; i++)
                {
                    if (seq.SetEquals(digits[i]))
                    {
                        outputValue += i.ToString();
                        break;
                    }
                }
            }

            return Convert.ToInt32(outputValue);
        }

        private void ParseInput(string input)
        {
            var raw = input.Split('|').Select(a => a.Trim()).ToArray();
            digitsRaw = raw[0].Split(' ').Select(a => a.Trim()).OrderBy(a => a.Length).ToList();
            output = raw[1].Split(' ').Select(a => a.Trim()).ToList();
        }

        private void ProcessDigits()
        {
            while (digitsRaw.Count > 0)
            {
                var currentPattern = digitsRaw[0].ToSignalPattern();

                if (digitsRaw[0].Length == 2) // It's 1
                {
                    digits[1] = currentPattern;
                }
                else if (digitsRaw[0].Length == 3) // It's 7
                {
                    digits[7] = currentPattern;
                }
                else if (digitsRaw[0].Length == 4) // It's 4
                {
                    digits[4] = currentPattern;
                }
                else if (digitsRaw[0].Length == 7) // It's 8
                {
                    digits[8] = currentPattern;
                }
                else if (digitsRaw[0].Length == 5) // 2, 3 or 5
                {
                    var exceptOne = currentPattern.Except(digits[1]);
                    if (digits[1].Count == 2 && exceptOne.Count() == 3) // It's 3
                    {
                        digits[3] = currentPattern;
                    }
                    else if (digits[4].Count == 4)
                    {
                        var exceptFour = currentPattern.Except(digits[4]);
                        if (exceptFour.Count() == 3) // It's 2
                        {
                            digits[2] = currentPattern;
                        }
                        else // It's 5
                        {
                            digits[5] = currentPattern;
                        }
                    }
                }
                else // 0, 6, 9
                {
                    if (digits[3].Count == 5 && digits[3].IsSubsetOf(currentPattern)) // It's 9
                    {
                        digits[9] = currentPattern;
                    }
                    else if (digits[1].Count == 2 && digits[1].IsSubsetOf(currentPattern)) // It's 0
                    {
                        digits[0] = currentPattern;
                    }
                    else // It's 6
                    {
                        digits[6] = currentPattern;
                    }
                }

                digitsRaw.RemoveAt(0);
            }
        }
    }
}
