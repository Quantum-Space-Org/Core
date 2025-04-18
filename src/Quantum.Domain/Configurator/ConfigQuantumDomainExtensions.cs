using Quantum.Configurator;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Quantum.Domain.Configurator;

public static class ConfigQuantumDomainExtensions
{
    public static ConfigQuantumDomainBuilder ConfigQuantumDomain(this QuantumServiceCollection collection)
    {
        return new ConfigQuantumDomainBuilder(collection);
    }
}

public class ConfigQuantumDomainBuilder(QuantumServiceCollection collection)
{
    public ConfigQuantumDomainBuilder RegisterDomainServicesInAssembliesAsTransient(params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var domainServices = assembly.GetTypes().Where(t => t.IsClass
                                                                && t.GetInterfaces() != null
                                                                && t.Name.EndsWith("DomainService"));
            foreach (var d in domainServices)
            {
                collection.Collection.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor
                    (d.GetInterfaces()[0], d, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient));
            }
        }
        return this;
    }

    public ConfigQuantumDomainBuilder RegisterCommandValidatorsInAssembliesAsSingletone(params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var domainServices = assembly.GetTypes().Where(t => t.IsClass
                                                                && t.GetInterfaces() != null
                                                                && t.Name.EndsWith("CommandValidator"));
            foreach (var d in domainServices)
            {
                collection.Collection.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor
                    (d.GetInterfaces()[0], d, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient));
            }
        }

        return this;
    }

    public ConfigQuantumDomainBuilder RegisterFacadeServicesInAssembliesAsTransient(params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var domainServices = assembly.GetTypes().Where(t => t.IsClass
                                                                && t.GetInterfaces() != null
                                                                && t.Name.EndsWith("Facade"));
            foreach (var d in domainServices)
            {
                collection.Collection.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor
                    (d.GetInterfaces()[0], d, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient));
            }
        }

        return this;
    }
        
    public QuantumServiceCollection and()
    {
        return collection;
    }
}