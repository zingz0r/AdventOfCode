using Common.Extensions;
using Common.Interfaces;

namespace _2023.Day04.Models;

public class Card : IModel
{
    public int Id { get; }
    public IList<int> WinningNumbers { get; }
    public IList<int> YourNumbers { get; }

    private static readonly char[] _separator = { ':', '|' };

    public Card(string line)
    {
        var items = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList();
        Id = items.PopFirst().GetNumbers().First();

        WinningNumbers = new List<int>(items.First().GetNumbers());
        YourNumbers = new List<int>(items.Last().GetNumbers());
    }
}