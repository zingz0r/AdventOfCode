namespace _2023.Day03.Extensions;

public static class StringExtensions
{
    public static char?[,] GetCharacterMatrix(this IList<string> lines)
    {
        var result = new char?[lines.Count, lines.First().Length];

        for (var i = 0; i < lines.Count; ++i)
        {
            for (var j = 0; j < lines[i].Length; ++j)
            {
                result[i, j] = lines[i][j] == '.' ? null : lines[i][j];
            }
        }

        return result;
    }
}