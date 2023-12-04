using _2015.Day01.Enums;
using _2015.Day01.Extensions;
using Common.Interfaces;

namespace _2015.Day01;

public class Solver : ISolver
{
    public string SolveFirst(string input)
    {
        int up = 0, down = 0;
        foreach (var character in input)
        {
            switch (character.ToEnum<Direction>())
            {
                case Direction.Up:
                    ++up;
                    break;
                case Direction.Down:
                    ++down;
                    break;
            }
        }

        return (up - down).ToString();
    }

    public string SolveSecond(string input)
    {
        int up = 0, down = 0;
        for (var i = 0; i< input.Length; ++i)
        {
            switch (input[i].ToEnum<Direction>())
            {
                case Direction.Up:
                    ++up;
                    break;
                case Direction.Down:
                    ++down;
                    break;
            }

            if (up - down == -1)
            {
                return (i + 1).ToString();
            } 
        }

        return string.Empty;
    }
}