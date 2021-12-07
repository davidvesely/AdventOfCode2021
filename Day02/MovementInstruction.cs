using System;

namespace Day02
{
    public class MovementInstruction
    {
        public Direction Direction { get; set; }

        public int Value { get; set; }

        public static MovementInstruction FromString(string input)
        {
            var elements = input.Split(' ');
            return new MovementInstruction
            {
                Direction = Enum.Parse<Direction>(elements[0], true),
                Value = int.Parse(elements[1])
            };
        }
    }
}
