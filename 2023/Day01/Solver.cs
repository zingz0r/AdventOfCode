using System.Text.RegularExpressions;
using Common.Extensions;
using Common.Interfaces;

namespace _2023.Day01;

public class Solver : ISolver
{
    private static readonly IDictionary<string, int> _numberLookupTable = new Dictionary<string, int>
    {
        { "1", 1 }, { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 },
        { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
    };
    
    public string SolveFirst(string input)
    {
        return input.GetLines().ToList()
            .Select(line => line.Where(char.IsDigit).ToArray())
            .Select(digits => int.Parse($"{digits.First()}{digits.Last()}"))
            .Sum()
            .ToString();
    }

    public string SolveSecond(string input)
    {
        return (from line in input.GetLines().ToList()
            let forwardMatch = Regex.Match(line, string.Join("|", _numberLookupTable.Keys), RegexOptions.IgnoreCase).Value 
            let backwardMatch = Regex.Match(line.Reverse(), string.Join("|", _numberLookupTable.Keys.Select(x => x.Reverse())), RegexOptions.IgnoreCase).Value 
            select int.Parse($"{_numberLookupTable[forwardMatch]}{_numberLookupTable[new string(backwardMatch.Reverse().ToArray())]}"))
            .Sum()
            .ToString();
    }
}