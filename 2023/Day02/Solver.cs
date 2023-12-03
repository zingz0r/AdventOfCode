using Common;
using Common.Extensions;
using Game = _2023.Day02.Models.Game;

namespace _2023.Day02;

public class Solver : ISolver
{
    public string SolveFirst(string input)
    {
        return GetGames(input).ToList()
            .Where(x => !x.Drafts.Any(y => y.Red > 12 || y.Green > 13 || y.Blue > 14))
            .Sum(x => x.Id)
            .ToString();
    }

    public string SolveSecond(string input)
    {
        return (from game in GetGames(input).ToList()
            let maxRed = game.Drafts.Max(x => x.Red)
            let maxGreen = game.Drafts.Max(x => x.Green)
            let maxBlue = game.Drafts.Max(x => x.Blue)
            select maxRed * maxGreen * maxBlue)
            .Sum()
            .ToString();
    }

    private static IEnumerable<Game> GetGames(string input)
    {
        return input.GetLines().Select(line => new Game(line));
    }
}