using System.Reflection;
using _2023.Day01;
using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Runner.Extensions;

namespace Runner;

internal static class Program
{
    private static IDictionary<int, Assembly> _assemblies = new Dictionary<int, Assembly>
    {
        { 2023, typeof(Solver).Assembly }
    };
    
    public static void Main(string[] args)
    {

        int year;
        Console.Write("Year: ");
        while (!int.TryParse(Console.ReadLine(), out year) || year < 2023 || year > 2023)
        {
            Console.Write("Year: ");
        }


        int day;
        Console.Write("Day: ");
        while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 3)
        {
            Console.Write("Day: ");
        }

        var assembly = _assemblies[year];
        var key = $"Day{day:d2}";
        var solverType = assembly.GetTypes().First(x => !string.IsNullOrEmpty(x.Namespace) && string.Equals(x.Namespace, $"_{year}.{key}"));
        var inputFile = Path.Combine(Path.GetDirectoryName(assembly.Location), key, "Input", "input.txt");
        
        var builder = new HostBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<ISolver>(_ => (ISolver)Activator.CreateInstance(solverType));
                services.AddSingleton<IRunner, Runner>();
            })
            .Build();
        
        builder.Services.GetService<IRunner>()?.Run(inputFile);
    }
}