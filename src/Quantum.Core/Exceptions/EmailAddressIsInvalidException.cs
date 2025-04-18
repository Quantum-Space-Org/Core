using System;

namespace Quantum.Core.Exceptions;

public class EmailAddressIsInvalidException : Exception
{
    public string Email { get; }

    public EmailAddressIsInvalidException(string email)
    {
        Email = email;
    }
}