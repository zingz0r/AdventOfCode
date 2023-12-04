using System.Reflection;
using _2023.Day01;
using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Runner;

internal static class Program
{
    private static IDictionary<int, Assembly> _assemblies = new Dictionary<int, Assembly>
    {
        { 2023, typeof(Solver).Assembly }
    };

    public static void Main(string[] args)
    {
        var year = 2023;//ReadConsole("Year", 2023, 2023);
        var day = 4;//ReadConsole("Day", 1, 4);

        var assembly = _assemblies[year];
        var key = $"Day{day:d2}";
        var solverType = assembly.GetTypes().First(x => !string.IsNullOrEmpty(x.Namespace) && string.Equals(x.Namespace, $"_{year}.{key}"));
        var inputFile = Path.Combine(Path.GetDirectoryName(assembly.Location)!, key, "Input", "input.txt");

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