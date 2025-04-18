using Quantum.Core;
using Quantum.Domain.BusinessRule;

namespace Quantum.UnitTests.Domain.TestSpecificClasses;

public class FakeAggregateRootEntity : IsAnAggregateRoot
{
    private readonly string _id;
    public string Value { get; }

    public FakeAggregateRootEntity(string id, string value)
    {
        _id = id;
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return _id;
    }
}

public class FakeGenericAggregateRootEntity : IsAnAggregateRoot<FakeEntityIdentity>
{
    private readonly FakeEntityIdentity _isAnIdentity;
    public string Value { get; }

    public FakeGenericAggregateRootEntity(FakeEntityIdentity isAnIdentity, string value)
        :base(isAnIdentity)
    {
        Value = value;
    }
}

public class FakeEntity : IsAnEntity
{
    private readonly FakeEntityIdentity _isAnIdentity;
    public string Value { get; }

    public FakeEntity(FakeEntityIdentity isAnIdentity, string value)
    {
        _isAnIdentity  = isAnIdentity;
        Value = value;
    }

    internal void CheckRule(IAmABusinessRule amABusinessRule)
    {
        base.CheckRule(amABusinessRule);
    }

    internal void CheckRules(List<IAmABusinessRule> businessRules)
    {
        base.CheckRules(businessRules);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return _isAnIdentity;
    }
}


public class FakeGenericEntity : IsAnEntity<FakeEntityIdentity>
{
    public string Value { get; }

    public FakeGenericEntity(FakeEntityIdentity isAnIdentity, string value)
        : base(isAnIdentity)
    {
        Value = value;
    }

    internal void CheckRule(IAmABusinessRule amABusinessRule)
    {
        base.CheckRule(amABusinessRule);
    }

    internal void CheckRules(List<IAmABusinessRule> businessRules)
    {
        base.CheckRules(businessRules);
    }
}

public class CustomerNameShouldNotBeEmpty : IAmABusinessRule
{
    private readonly string _value;
    private string _expectedMessage;

    public static CustomerNameShouldNotBeEmpty
        WhichAlwaysRaiseExceptionWithMessage(string message) =>
        new CustomerNameShouldNotBeEmpty("")
        {
            _expectedMessage = message
        };
    public CustomerNameShouldNotBeEmpty(string value)
    {
        _value = value;
    }
    public bool IsPassed()
    {
        return This.Is.True(!string.IsNullOrWhiteSpace(_value));
    }

    public string GetViolationRuleMessage()
    {
        _expectedMessage = "value can not be null";
        return _expectedMessage;
    }
}