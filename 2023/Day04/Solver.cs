using System;
using System.Collections.Generic;
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
            .Where(x => x.Matches.Any())
            .Select(x => Math.Pow(2, x.Matches.Count() - 1))
            .Sum()
            .ToString(CultureInfo.InvariantCulture);
    }

    public string SolveSecond(string input)
    {
        var cards = input.ParseLinesAs<Card>().ToList();
        var counts = Enumerable.Repeat(1, cards.Count).ToArray();

        for (var i = 0; i < cards.Count; ++i)
        {
            for (var j = 0; j < cards[i].Matches.Count; ++j)
            {
                counts[i + j + 1] += counts[i];
            }
        }

        return counts.Sum().ToString();
    }
}