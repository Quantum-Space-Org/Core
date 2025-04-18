using System.Linq;
using Quantum.Domain.BusinessRule;

namespace Quantum.Domain;

public abstract class IsAValueObject<T>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    protected void CheckRule(IAmABusinessRule amABusinessRule)
        => amABusinessRule.AssertThatIsValid();

    protected void CheckRules(List<IAmABusinessRule> businessRules)
        => businessRules.AssertThatAreValid();

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (GetType() != obj.GetType())
            return false;

        var that = (IsAValueObject<T>)obj;
        var equalityComponents = that.GetEqualityComponents();

        return GetEqualityComponents().SequenceEqual(equalityComponents);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(seed: 1, (currentValue, equalComponent) =>
            {
                unchecked
                {
                    return currentValue * 23 + (equalComponent?.GetHashCode() ?? 0);
                }
            });
    }

    public static bool operator ==(IsAValueObject<T> firstArgument, IsAValueObject<T> secondArgument)
    {
        if (ReferenceEquals(firstArgument, null) && ReferenceEquals(secondArgument, null))
            return true;

        if (ReferenceEquals(firstArgument, null) || ReferenceEquals(secondArgument, null))
            return false;

        return firstArgument.Equals(secondArgument);
    }

    public static bool operator !=(IsAValueObject<T> firstArgument, IsAValueObject<T> secondArgument)
    {
        return !(firstArgument == secondArgument);
    }
}