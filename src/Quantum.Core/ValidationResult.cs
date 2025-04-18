using System.Collections.Generic;
using System.Linq;

namespace Quantum.Core;

public class ValidationResult
{
    public ICollection<Result> Results = new List<Result>();
    public bool IsSucceeded => 
        Results.Any() is false 
        || Results.All(r => r.IsSucceeded);

    public static ValidationResult Fail(Result result)
    {
        return new ValidationResult
        {
            Results = new List<Result>
            {
                result
            }
        };
    }

    public static ValidationResult Warning(Result result)
    {
        return new ValidationResult
        {
            Results = new List<Result>
            {
                result
            }
        };
    }

    public static ValidationResult Success()
        => new();

    public void AddFail(Result result)
        => Results.Add(result);

    public void AddWarning(Result result)
        => Results.Add(result);
}