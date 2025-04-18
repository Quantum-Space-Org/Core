using System;

namespace Quantum.Core.Exceptions;

public class ParameterNullOrEmptyDomainException : Exception
{
    public ParameterNullOrEmptyDomainException(string parameterName, object enteredValue, string message)
        : base(message)
    {
        ParameterName = parameterName;
        EnteredValue = enteredValue;
    }

    public string ParameterName { get; }
    public object EnteredValue { get; }
}