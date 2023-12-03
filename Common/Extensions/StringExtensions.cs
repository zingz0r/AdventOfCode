namespace Common.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> GetLines(this string input)
    {
        return input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }
    
    public static string Reverse(this string input)
    {
        return new string(Enumerable.Reverse(input).ToArray());
    }
}