using System.Reflection;
using Common;
using Microsoft.Extensions.DependencyInjection;

namespace Runner.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSingletonFromAllAssemblies<T>(this IServiceCollection services)
    {
        var @interface = typeof(T);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(c => @interface.IsAssignableFrom(c) && c.IsClass);
        
        foreach (var type in types)
        {
            services.AddKeyedSingleton(type.Assembly.GetName(), type);
        }

        return services;
    }
}