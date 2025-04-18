using Microsoft.Extensions.DependencyInjection;
using Quantum.Core.Exceptions;
using Quantum.Resolver;
using Quantum.Resolver.ServiceCollection;
using Quantum.UnitTests.Resolver.TestSpecificClasses;

namespace Quantum.UnitTests.Resolver;

public class ResolverTests
{

    [Fact]
    public void Resolve_IsNotRegisteredDependency_ExceptionThrown()
    {
        IServiceCollection serviceCollection = GetServiceCollection();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        IResolver resolver = new ServiceCollectionResolver(serviceProvider);
        var result = Assert.Throws<QuantumComponentIsNotRegisteredException>(() => resolver.Resolve<FakeCommand>());
        Assert.Equal($"{typeof(FakeCommand).FullName} is not registered!", result.Message);
    }

        

    private IServiceCollection GetServiceCollection() => new ServiceCollection();
}