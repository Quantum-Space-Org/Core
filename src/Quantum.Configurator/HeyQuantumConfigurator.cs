using Microsoft.Extensions.DependencyInjection;

namespace Quantum.Configurator;

public class HeyQuantumConfigurator
{
    private QuantumServiceCollection _quantumServiceCollection;
    public static HeyQuantumConfigurator I => new HeyQuantumConfigurator();
    public QuantumServiceCollection To => _quantumServiceCollection;

    public QuantumServiceCollection WantToUse(IServiceCollection serviceCollection)
    {
        _quantumServiceCollection = new QuantumServiceCollection(serviceCollection);
        return _quantumServiceCollection;
    }
}