using System;
using System.Collections.Generic;
using Quantum.Core.Exceptions;

namespace Quantum.Resolver.ServiceCollection;

public class ServiceCollectionResolver : IResolver
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceCollectionResolver(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;


    public object Resolve(Type type)
    {
        var component = _serviceProvider.GetService(type);
        if (component == null)
            throw new QuantumComponentIsNotRegisteredException(type);

        return component;
    }

    public T Resolve<T>()
    {
        var component = _serviceProvider.GetService(typeof(T));
        if (component == null)
            throw new QuantumComponentIsNotRegisteredException(typeof(T));

        return (T)component;
    }

    public IEnumerable<T> ResolveAll<T>() => (IEnumerable<T>)_serviceProvider.GetService(typeof(IEnumerable<T>));
}
