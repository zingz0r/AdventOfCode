namespace _2015.Day01.Extensions;

public static class EnumExtensions
{
    public static char ToCharacter<TEnum>(this TEnum @enum)
        where TEnum : Enum
    {
        return Convert.ToChar(@enum);
    }
    
    public static TEnum ToEnum<TEnum>(this char character)
        where TEnum : Enum
    {
        return (TEnum)Enum.ToObject(typeof(TEnum), character);
    }
}