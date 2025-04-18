using System;

namespace Quantum.Core.Exceptions;

public class IllegalArgumentException : Exception
{
    public IllegalArgumentException(string message)
        :base(message){
            
    }
}