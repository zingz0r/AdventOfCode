using Common.Extensions;
using Common.Interfaces;

namespace _2023.Day02.Models;

public class Game : IModel
{
    public int Id { get; }
    public IList<Draft> Drafts { get; } = new List<Draft>();

    private const string _zero = "0";
    private static readonly char[] _gameAndDraftSeparator = { ':', ';' };

    public Game(string line)
    {
        var items = line.Split(_gameAndDraftSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();
        Id = items.PopFirst().GetNumbers().First();

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
            Red = reds.GetNumbers().First(),
            Green = greens.GetNumbers().First(),
            Blue = blues.GetNumbers().First()
        };
    }
}