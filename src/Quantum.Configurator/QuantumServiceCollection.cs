using System;
using Microsoft.Extensions.DependencyInjection;

namespace Quantum.Configurator
{
    public class QuantumServiceCollection
    {
        public readonly IServiceCollection Collection;
        public QuantumServiceCollection To => this;

        public QuantumServiceCollection()
            => Collection = new ServiceCollection();

        public QuantumServiceCollection(IServiceCollection serviceCollection)
            =>  Collection = serviceCollection;
    }
}