using System.Reflection;
using System.Text.RegularExpressions;
using Common.Interfaces;

namespace Common.Extensions;

public static partial class StringExtensions
{
    public static IEnumerable<string> GetLines(this string input)
    {
        return input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }

    public static string Reverse(this string input)
    {
        return new string(Enumerable.Reverse(input).ToArray());
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitRegex();
    public static IEnumerable<int> GetNumbers(this string input)
    {
        return DigitRegex().Matches(input).Select(x => int.Parse(x.Value));
    }

    public static IEnumerable<TModel> ParseLinesAs<TModel>(this string input)
        where TModel : IModel
    {
        return input.GetLines().Select(line => (TModel)Activator.CreateInstance(typeof(TModel), line)!);
    }
}