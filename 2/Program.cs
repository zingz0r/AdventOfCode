namespace _2;

internal class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("Input/input.txt");
        var games = lines.Select(line => new Models.Game(line)).ToList();

        var part1 = games
            .Where(x => !x.Drafts.Any(y => y.Red > 12 || y.Green > 13 || y.Blue > 14))
            .Sum(x => x.Id);

        Console.WriteLine($"[Part 1] Dear Elf, the sum of the IDs of the questioned games is: {part1}");

        var part2 = (from game in games
            let maxRed = game.Drafts.Max(x => x.Red)
            let maxGreen = game.Drafts.Max(x => x.Green)
            let maxBlue = game.Drafts.Max(x => x.Blue)
            select maxRed * maxGreen * maxBlue).Sum();

        Console.WriteLine($"[Part 2] Dear Elf, the sum of the power of the sets is: {part2}");
    }
}