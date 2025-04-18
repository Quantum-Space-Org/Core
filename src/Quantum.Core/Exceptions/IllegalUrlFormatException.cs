using System;

namespace Quantum.Core.Exceptions;

public class IllegalUrlFormatException : Exception
{
    public IllegalUrlFormatException(string message)
        :base(message){
            
    }
}