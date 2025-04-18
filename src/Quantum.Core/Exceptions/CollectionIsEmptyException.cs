using System;

namespace Quantum.Core.Exceptions;

public class CollectionIsEmptyException : Exception
{
    public string CollectionName { get; }

    public static CollectionIsEmptyException Occured(string collectionName) 
        => new CollectionIsEmptyException(collectionName);
    public CollectionIsEmptyException(string collectionName)
    {
        CollectionName = collectionName;
    }
}