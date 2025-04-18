using System.Collections.Generic;
using System.Linq;

namespace Quantum.Core;

public class ParameterBasedResult : Result
{
    public ParameterBasedResult(string message, string messageKey, List<string> parametersKey, bool isWarning = false, string @namespace = "i18n") : base(message, messageKey, parametersKey, isWarning, @namespace)
    {
    }
}

public class Result
{
    public string Message { get; protected set; }
    public string MessageKey { get; protected set; }
    public List<string> ParameterKeys { get; protected set; }
    public bool IsSucceeded { protected set; get; }
    public string Namespace { get; set; } = DefaultNameSpace;

    public const string DefaultNameSpace = "i18n";

    protected Result()
    {
    }

    public Result(string message, string messageKey,
        List<string> parametersKey,
        bool isWarning = false,
        string @namespace = "i18n")
    {
        Message = message;
        MessageKey = messageKey;
        ParameterKeys = parametersKey;
        Namespace = @namespace;
    }

    public Result(bool isSucceeded,
        string message,
        string messageKey,
        List<string> parametersKey,
        bool isWarning = false,
        string @namespace = "i18n")
        : this(message, messageKey, parametersKey, isWarning
            , @namespace)
    {
        IsSucceeded = isSucceeded;
    }

    public static Result Success(string messageKey = "", List<string> parametersKey = null, bool isWarning = false)
        => new(string.Empty, messageKey, parametersKey)
        {
            IsSucceeded = true
        };

    public static Result ParameterBasedFail(string message, string messageKey = "", params string[] parametersKeys)
        => new ParameterBasedResult(message, messageKey, parametersKeys.ToList());

    public static Result Warning(string message, string messageKey = "", List<string> parametersKey = null, bool isWarning = false)
        => new(message, messageKey, parametersKey, isWarning);

    public static Result Fail(string message) => new FailResult(message);
    public static Result Fail(string messageKey, params string[] parameterKeys) => new FailResult(messageKey, parameterKeys);
    public static Result Fail(string @namespace, string messageKey, params string[] parameterKeys) => new FailResult(@namespace, messageKey, parameterKeys);

    public static Result Fail(string message, string @namespace, string messageKey, params string[] parametersKeys) =>
        new FailResult(message, @namespace, messageKey, parametersKeys);
    public static Result Fail(string message, string messageKey = "", List<string> parametersKey = null)
        => new(false, message, messageKey, parametersKey);
    //public static Result Fail(string message, string messageKey = "", params string[] parametersKeys)
    //    => new(false, message, messageKey, parametersKeys.ToList());

    
}

public class FailResult : Result
{
    public FailResult(string message)
    {
        IsSucceeded = false;
        Message = message;
    }

    public FailResult(string messageKey, params string[] parameterKeys)
    {
        IsSucceeded = false;
        MessageKey = messageKey;
        ParameterKeys = parameterKeys.ToList();
    }

    public FailResult(string @namespace, string messageKey, params string[] parameterKeys)
    {
        IsSucceeded = false;
        MessageKey = messageKey;
        ParameterKeys = parameterKeys.ToList();
        Namespace = @namespace;
    }

    public FailResult(string message, string @namespace, string messageKey, params string[] parametersKeys)
        : base(false, "", "", null, false, "")
    {
        IsSucceeded = false;

        Message = message;
        MessageKey = messageKey;
        ParameterKeys = parametersKeys.ToList();
        Namespace = @namespace;
    }
}