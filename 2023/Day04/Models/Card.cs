using Common.Extensions;
using Common.Interfaces;

namespace _2023.Day04.Models;

public class Card : IModel
{
    public int Id { get; }

    public IList<int> Matches => _winningNumbers.Intersect(_yourNumbers).ToList();

    private static readonly char[] _separator = { ':', '|' };

    private readonly IEnumerable<int> _winningNumbers;
    private readonly IEnumerable<int> _yourNumbers;
    
    public Card(string line)
    {
        var items = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries).ToList();
        Id = items.PopFirst().GetNumbers().First();

        _winningNumbers = new List<int>(items.First().GetNumbers());
        _yourNumbers = new List<int>(items.Last().GetNumbers());
    }
}