namespace Quantum.Core.Configure;

using Microsoft.Extensions.DependencyInjection;
using Quantum.Configurator;

public static class ConfigQuantumCoreServicesExtensions
{
    public static ConfigQuantumCoreServicesBuilder ConfigQuantumCoreServices(this QuantumServiceCollection collection)
    {
        return new ConfigQuantumCoreServicesBuilder(collection);
    }
}

public class ConfigQuantumCoreServicesBuilder
{
    private readonly QuantumServiceCollection _quantumServiceCollection;

    public ConfigQuantumCoreServicesBuilder(QuantumServiceCollection collection)
    {
        _quantumServiceCollection = collection;
    }

    public QuantumServiceCollection and()
    {
        return _quantumServiceCollection;
    }

    public ConfigQuantumCoreServicesBuilder RegisterDateTimeProviderAsSingletone<T>()
        where T : class, IDateTimeProvider
    {
        _quantumServiceCollection.Collection.AddSingleton<IDateTimeProvider, T>();

        return this;
    }

    public ConfigQuantumCoreServicesBuilder RegisterDateTimeProvider<T>(ServiceLifetime serviceLifetime)
        where T : class, IDateTimeProvider
    {
        _quantumServiceCollection.Collection.Add(new ServiceDescriptor(typeof(IDateTimeProvider), typeof(T), serviceLifetime));

        return this;
    }
}