namespace _1.Extensions;

public static class StringExtensions
{
    public static string Reverse(this string line)
    {
        return new string(Enumerable.Reverse(line).ToArray());
    }
}