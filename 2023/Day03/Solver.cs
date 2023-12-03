using _2023.Day03.Extensions;
using Common;
using Common.Extensions;

namespace _2023.Day03;

public class Solver : ISolver
{
    public string SolveFirst(string input)
    {
        return ExtractPartNumbers(input.GetLines().ToList())
            .Sum()
            .ToString();
    }

    public string SolveSecond(string input)
    {
        return ExtractGears(input.GetLines().ToList())
            .Sum()
            .ToString();
    }

    private static IEnumerable<int> ExtractPartNumbers(IReadOnlyList<string> lines)
    {
        var result = new List<int>();
        for (var row = 0; row < lines.Count; ++row)
        {
            for (var col = 0; col < lines[row].Length; ++col)
            {
                if (!lines[row][col].IsSymbol())
                {
                    continue;
                }

                result.AddRange(GetSurroundingPartNumbers(lines, row, col));
            }
        }

        return result;
    }
    
    private static IEnumerable<int> ExtractGears(IReadOnlyList<string> lines)
    {
        var result = new List<int>();
        for (var row = 0; row < lines.Count; ++row)
        {
            for (var col = 0; col < lines[row].Length; ++col)
            {
                if (!lines[row][col].IsSymbol())
                {
                    continue;
                }

                var partNumbers = GetSurroundingPartNumbers(lines, row, col).ToList();
                if (partNumbers.Count == 2)
                {
                    result.Add(partNumbers.Aggregate((first, second) => first * second));
                }
            }
        }

        return result;
    }

    private static IEnumerable<int> GetSurroundingPartNumbers(IReadOnlyList<string> lines, int row, int col)
    {
        var result = new List<int>();

        for (var rowDelta = -1; rowDelta <= 1; ++rowDelta)
        {
            for (var colDelta = -1; colDelta <= 1; ++colDelta)
            {
                var peekRowIndex = row + rowDelta;
                var peekColumnIndex = col + colDelta;

                if (peekRowIndex == row && peekColumnIndex == col
                    || peekRowIndex >= lines.Count
                    || peekColumnIndex >= lines[peekRowIndex].Length
                    || peekRowIndex < 0
                    || peekColumnIndex < 0
                    || !char.IsDigit(lines[peekRowIndex][peekColumnIndex]))
                {
                    continue;
                }

                while (--peekColumnIndex > 0 && char.IsDigit(lines[peekRowIndex][peekColumnIndex]))
                {
                }

                var number = "";
                if (peekColumnIndex == 0 || peekColumnIndex == lines[peekRowIndex].Length - 1)
                {
                    number += lines[peekRowIndex][peekColumnIndex];
                }

                while (++peekColumnIndex < lines[peekRowIndex].Length && char.IsDigit(lines[peekRowIndex][peekColumnIndex]))
                {
                    number += lines[peekRowIndex][peekColumnIndex];
                }

                if (!string.IsNullOrEmpty(number))
                {
                    result.Add(int.Parse(number));
                }

                colDelta = peekColumnIndex - col;
            }
        }

        return result;
    }
}