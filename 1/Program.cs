using System.Text.RegularExpressions;
using _1.Extensions;

namespace _1;

internal class Program
{
    private static readonly IDictionary<string, int> _numberLookupTable = new Dictionary<string, int>
    {
        { "1", 1 }, { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 },
        { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
    };
    
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("Input/input.txt");

        var part1 = lines.Sum(Part1);
        Console.WriteLine($"[Part 1] Dear Elves, the sum of all of the calibration values is: {part1}");

        var part2 = lines.Sum(Part2);
        Console.WriteLine($"[Part 2] Dear Elves, the CORRECT sum of all of the calibration values is: {part2}");
    }

    private static int Part1(string line)
    {
        var digits = line.Where(char.IsDigit).ToArray();
        return int.Parse($"{digits.First()}{digits.Last()}");
    }

    private static int Part2(string line)
    {
        var forwardMatch = Regex.Match(line, string.Join("|", _numberLookupTable.Keys), RegexOptions.IgnoreCase).Value;
        var backwardMatch = Regex.Match(line.Reverse(), string.Join("|", _numberLookupTable.Keys.Select(x => x.Reverse())), RegexOptions.IgnoreCase).Value;

        return int.Parse($"{_numberLookupTable[forwardMatch]}{_numberLookupTable[new string(backwardMatch.Reverse().ToArray())]}");
    }
}