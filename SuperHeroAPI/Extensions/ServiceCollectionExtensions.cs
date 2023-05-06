namespace SuperHeroAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNamed<TService>(this IServiceCollection services, string name, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        return services.AddSingleton(provider => new NamedService<TService>(name, implementationFactory(provider)));
    }

    public static TService? GetNamed<TService>(this IServiceProvider serviceProvider, string name) where TService : class
    {
        var services = serviceProvider.GetServices<NamedService<TService>>();
        var namedService = services.FirstOrDefault(s => s.Name == name);
        return namedService?.Service;
    }

    private class NamedService<TService> where TService : class
    {
        public string Name { get; }
        public TService Service { get; }

        public NamedService(string name, TService service)
        {
            Name = name;
            Service = service;
        }
    }
}