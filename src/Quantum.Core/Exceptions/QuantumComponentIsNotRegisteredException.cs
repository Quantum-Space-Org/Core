using System;

namespace Quantum.Core.Exceptions;

public class QuantumComponentIsNotRegisteredException : Exception
{
    public static QuantumComponentIsNotRegisteredException Occured(Type type)
        => new(type);
    public QuantumComponentIsNotRegisteredException(Type type)
        :base($"{type?.FullName} is not registered!")
    {
            
    }
}