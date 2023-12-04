using System.Reflection;
using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Runner;

internal static class Program
{
    private static readonly IDictionary<int, Assembly> _assemblies = new Dictionary<int, Assembly>
    {
        { 2015, typeof(_2015.Day01.Solver).Assembly },
        { 2023, typeof(_2023.Day01.Solver).Assembly }
    };

    public static void Main(string[] args)
    {
        var year = ReadConsole("Year", 2015, 2023);
        var day = ReadConsole("Day", 1, 31);

        var assembly = _assemblies[year];
        var key = $"Day{day:d2}";
        var solverType = assembly.GetTypes().First(x => x.IsClass && x.GetInterfaces().Contains(typeof(ISolver)));
        var inputFile = Path.Combine(Path.GetDirectoryName(assembly.Location)!, year.ToString(), key, "Input", "input.txt");

        var builder = new HostBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<ISolver>(_ => (ISolver)Activator.CreateInstance(solverType)!);
                services.AddSingleton<IRunner, Runner>();
            })
            .Build();

        builder.Services.GetService<IRunner>()?.Run(inputFile);
    }

    private static int ReadConsole(string consoleText, int low, int high)
    {
        int result;
        consoleText = $"{consoleText}: ";
        
        Console.Write(consoleText);
        while (!int.TryParse(Console.ReadLine(), out result) || result > high || result < low)
        {
            Console.Write(consoleText);
        }

        return result;
    }
}