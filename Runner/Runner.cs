using Common;

namespace Runner;

public class Runner(ISolver solver) : IRunner
{
    public void Run(string inputFile)
    {
        var input = File.ReadAllText(inputFile);

        Console.WriteLine($"Solution for part 1 is: {solver.SolveFirst(input)}");
        Console.WriteLine($"Solution for part 2 is: {solver.SolveSecond(input)}");
    }
}