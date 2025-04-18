using System;

namespace Quantum.Core.Exceptions;

public class CommandHandlerIsNotRegisteredException : Exception
{
    public Type CommandType { get; }

    public static CommandHandlerIsNotRegisteredException
        Occured(Type commandType) => new(commandType);

    public CommandHandlerIsNotRegisteredException(Type commandType)
    {
        CommandType = commandType;
    }
}