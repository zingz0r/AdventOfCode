using System.Globalization;
using _2023.Day04.Models;
using Common.Extensions;
using Common.Interfaces;

namespace _2023.Day04;

public class Solver : ISolver
{
    public string SolveFirst(string input)
    {
        return input.ParseLinesAs<Card>()
            .Select(x => x.WinningNumbers.Intersect(x.YourNumbers))
            .Where(x => x.Any())
            .Select(x => Math.Pow(2, x.Count() - 1))
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    public string SolveSecond(string input)
    {
        return "";
    }
}