using System.Linq;

namespace Day04
{
    public class Board
    {
        private readonly int[,] _data;

        private readonly bool[,] _marking;

        public Board(int[,] data)
        {
            _data = data;
            _marking = new bool[data.GetLength(0), data.GetLength(1)];
        }

        public int SumUnmarked
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _data.GetLength(0); i++)
                {
                    for (int j = 0; j < _data.GetLength(1); j++)
                    {
                        if (!_marking[i, j])
                        {
                            sum += _data[i, j];
                        }
                    }
                }

                return sum;
            }
        }

        public bool MarkNumber(int number)
        {
            for (int i = 0; i < _data.GetLength(0); i++)
            {
                for (int j = 0; j < _data.GetLength(1); j++)
                {
                    if (_data[i, j] == number)
                    {
                        _marking[i, j] = true;
                    }
                }
            }

            return IsWinner;
        }

        public bool IsWinner
        {
            get
            {
                // Check columns
                for (int i = 0; i < _marking.GetLength(0); i++)
                {
                    if (ArrayExtensions.GetColumn(_marking, i).All(a => a))
                        return true;
                }

                // Check rows
                for (int i = 0; i < _marking.GetLength(1); i++)
                {
                    if (ArrayExtensions.GetRow(_marking, i).All(a => a))
                        return true;
                }

                return false;
            }
        }

        public override string ToString()
        {
            var markinsString = _marking.Select(a => a ? "*" : "_");
            return $"{_data.ToMatrixString()}\n\n{markinsString.ToMatrixString()}";
        }
    }
}
