using System;

namespace QuadraticSolver
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Quadratic equation calculator");
            Console.WriteLine();
            int a = InputParameter("a");
            int b = InputParameter("b");
            int c = InputParameter("c");

            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
            {
                Console.WriteLine("Negative discriminant, there are no solutions");
            }
            else if (discriminant == 0)
            {
                int x = -b / (2 * a);
                Console.WriteLine($"There is only one x: {x}");
            }
            else if (discriminant > 0)
            {
                double discriminantSqrt = Math.Sqrt(discriminant);
                if (discriminantSqrt % 1 != 0)
                {
                    Console.WriteLine("Square root of D is not an integer");
                    Environment.Exit(0);
                }

                int x1 = (-b + (int)discriminantSqrt) / (2 * a);
                int x2 = (-b - (int)discriminantSqrt) / (2 * a);

                Console.WriteLine($"x1: {x1}");
                Console.WriteLine($"x2: {x2}");
            }
        }

        private static int InputParameter(string name)
        {
            Console.Write($"Enter {name}: ");
            string value = Console.ReadLine();
            try
            {
                return int.Parse(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a valid number");
                Environment.Exit(0);
                return 0;
            }
        }
    }
}
