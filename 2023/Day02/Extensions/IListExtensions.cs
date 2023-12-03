namespace _2023.Day2.Extensions;

public static class ListExtensions
{
    public static T PopFirst<T>(this IList<T> enumerable)
    {
        var result = enumerable.First();
        enumerable.RemoveAt(0);

        return result;
    }
}