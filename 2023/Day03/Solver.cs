using _2023.Day03.Extensions;
using Common;
using Common.Extensions;

namespace _2023.Day03;

public class Solver : ISolver
{
    public string SolveFirst(string input)
    {
        return ExtractPartNumbers(input.GetLines().ToList().GetCharacterMatrix())
            .Sum()
            .ToString();
    }
    
    public string SolveSecond(string input)
    {
        return string.Empty;
    }
    
    private static IEnumerable<int> ExtractPartNumbers(char?[,] matrix)
    {
        var result = new List<int>();
        for (var k = 0; k < matrix.GetLength(0); ++k)
        {
            for (var l = 0; l < matrix.GetLength(1); ++l)
            {
                if (!matrix[k, l].IsDigit())
                {
                    continue;
                }

                if (!IsPartNumber(matrix, k, l))
                {
                    continue;
                }
                
                while (--l > 0 && matrix[k, l].IsDigit()) { }
                
                var number = "";
                if (l == 0 || l == matrix.GetLength(1) - 1)
                {
                    number += matrix[k, l];
                }
                
                while (++l < matrix.GetLength(1) && matrix[k, l].IsDigit())
                {
                    number += matrix[k, l];
                }
                
                result.Add(int.Parse(number));
            }
            
        }

        return result;
    }

    private static bool IsPartNumber(char?[,] matrix, int row, int column)
    {
        for (var i = -1; i <= 1; ++i)
        {
            for (var j = -1; j <= 1; ++j)
            {
                var peekRowIndex = row + i;
                var peekColumnIndex = column + j;

                if (peekRowIndex == row && peekColumnIndex == column
                    || peekRowIndex >= matrix.GetLength(0)
                    || peekColumnIndex >= matrix.GetLength(1)
                    || peekRowIndex < 0
                    || peekColumnIndex < 0)
                {
                    continue;
                }

                if (matrix[peekRowIndex, peekColumnIndex].IsSymbol())
                {
                    return true;
                }
            }
        }

        return false;
    }

}