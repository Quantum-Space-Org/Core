using System.Linq;
using Quantum.Domain.BusinessRule;

namespace Quantum.Domain;


public abstract class IsAnEntity
{
    protected void CheckRule(IAmABusinessRule amABusinessRule)
        => amABusinessRule.AssertThatIsValid();

    protected void CheckRules(List<IAmABusinessRule> businessRules)
        => businessRules.AssertThatAreValid();

    public abstract IEnumerable<object> GetEqualityComponents();

    public static bool operator ==(IsAnEntity @this, IsAnEntity that)
    {
        if (@this is null && that is null)
            return true;

        if (@this is not null && that is null)
            return false;

        if (@this is null && that is not null)
            return false;

        return @this.Equals(that);
    }

    public static bool operator !=(IsAnEntity @this, IsAnEntity that)
        => !(@this == that);

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (GetType() != obj.GetType())
            return false;

        var that = (IsAnEntity)obj;
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
}

public abstract class IsAnEntity<TIdentity>(TIdentity isAnIdentity)
    : IsAnEntity where TIdentity : IsAnIdentity<TIdentity>
{
    public TIdentity Identity { get; } = isAnIdentity;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Identity;
    }
    public override int GetHashCode()
        => Identity.GetHashCode();
}