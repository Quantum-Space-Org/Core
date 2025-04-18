using System;
using Microsoft.Extensions.DependencyInjection;
using Quantum.Resolver;

namespace Quantum.Configurator;

public static class ConfigureResolverExtensions
{
    public static QuantumServiceCollection UseServiceCollectionResolverAsResolver(this QuantumServiceCollection collection, Func<IServiceProvider, IResolver> factoryFunction)
    {
        collection.Collection.AddSingleton(factoryFunction);
        return collection;
    }

    public static QuantumServiceCollection UseServiceCollectionResolverAsTransient(this QuantumServiceCollection collection, Func<IServiceProvider, IResolver> factoryFunction)
    {
        collection.Collection.AddTransient(factoryFunction);
        return collection;
    }
}