using System;

namespace Quantum.Core.Exceptions;

public class ArgumentLengthException : Exception
{
    public static ArgumentLengthException Occured(string message)
    {
        return new ArgumentLengthException(message);
    }

    private ArgumentLengthException(string message)
        :base(message){ }
}