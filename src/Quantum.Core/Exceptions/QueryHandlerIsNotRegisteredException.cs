using System;

namespace Quantum.Core.Exceptions;

public class QueryHandlerIsNotRegisteredException : Exception
{
    public Type QueryHandlerType { get; }

    public static QueryHandlerIsNotRegisteredException
        Occured(Type queryHandlerType) => new(queryHandlerType);
    public QueryHandlerIsNotRegisteredException(Type queryHandlerType)
    {
        QueryHandlerType = queryHandlerType;
    }
}