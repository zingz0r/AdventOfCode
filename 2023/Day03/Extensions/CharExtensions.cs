namespace _2023.Day03.Extensions;

public static class CharExtensions
{
    public static bool IsSymbol(this char? character)
    {
        return character != null && !char.IsDigit(character.Value);
    }

    public static bool IsDigit(this char? character)
    {
        return character != null && char.IsDigit(character.Value);
    }
}