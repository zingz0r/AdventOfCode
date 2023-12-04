using _2015.Day01.Enums;
using _2015.Day01.Extensions;
using _2015.Day02.Models;
using Common.Extensions;
using Common.Interfaces;

namespace _2015.Day02;

public class Solver : ISolver
{
    public string SolveFirst(string input)
    {
        return input.ParseLinesAs<Surface>()
            .Select(x => 2 * x.AreaDimensions[0] + 2 * x.AreaDimensions[1] + 2 * x.AreaDimensions[2] + x.AreaDimensions.Min() )
            .Sum()
            .ToString();
    }

    public string SolveSecond(string input)
    {
        return input.ParseLinesAs<Surface>()
            .Select(x => 2 * x.Perimeters.Min() + x.Volume)
            .Sum()
            .ToString();
    }
}