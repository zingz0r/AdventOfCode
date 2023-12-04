namespace Common.Extensions;

public static class ListExtensions
{
    public static T PopFirst<T>(this IList<T> list)
    {
        var result = list.First();
        list.RemoveAt(0);

        return result;
    }
}