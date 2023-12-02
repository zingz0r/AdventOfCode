using System.Text.RegularExpressions;
using _2.Extensions;

namespace _2.Models;

public partial class Game
{
    public int Id { get; }
    public IList<Draft> Drafts { get; } = new List<Draft>();

    private const string _zero = "0";
    private static readonly char[] _gameAndDraftSeparator = { ':', ';' };

    [GeneratedRegex(@"\d+", RegexOptions.Compiled)]
    private static partial Regex DigitRegex();

    public Game(string line)
    {
        var items = line.Split(_gameAndDraftSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();
        Id = GetNumbers(items.PopFirst()).First();

        foreach (var item in items)
        {
            Drafts.Add(ParseDraft(item.Split(',', StringSplitOptions.RemoveEmptyEntries)));
        }
    }

    private static Draft ParseDraft(IList<string> cubes)
    {
        var reds = cubes.FirstOrDefault(x => x.Contains(Colors.Red.ToString(), StringComparison.InvariantCultureIgnoreCase)) ?? _zero;
        var greens = cubes.FirstOrDefault(x => x.Contains(Colors.Green.ToString(), StringComparison.InvariantCultureIgnoreCase)) ?? _zero;
        var blues = cubes.FirstOrDefault(x => x.Contains(Colors.Blue.ToString(), StringComparison.InvariantCultureIgnoreCase)) ?? _zero;

        return new Draft
        {
            Red = GetNumbers(reds).First(),
            Green = GetNumbers(greens).First(),
            Blue = GetNumbers(blues).First(),
        };
    }

    private static IEnumerable<int> GetNumbers(string text)
    {
        return DigitRegex().Matches(text).Select(x => int.Parse(x.Value));
    }
}