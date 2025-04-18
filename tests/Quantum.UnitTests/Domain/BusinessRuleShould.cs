using Quantum.Domain.BusinessRule;

namespace Quantum.UnitTests.Domain;

public class BusinessRuleShould
{
    string valueCanNotBeNull = "Value can not be null!";

    [Fact]
    public void Check_correctly()
    {
        var fakeEntity = CreateFakeEntity();

        var action = () => fakeEntity.CheckRule(CustomerNameShouldNotBeEmpty.WhichAlwaysRaiseExceptionWithMessage(valueCanNotBeNull));
        var result = action.Should().Throw<DomainValidationException>();
    }

    private static FakeGenericEntity CreateFakeEntity()
    {
        var fakeEntity = new FakeGenericEntity(new FakeEntityIdentity(1), "some value");
        return fakeEntity;
    }

    [Fact]
    public void Check_multiple_business_rules_correctly()
    {
        var fakeEntity = CreateFakeEntity();

        var action = () =>
            fakeEntity.CheckRules(
                new List<IAmABusinessRule>
                {
                    new CustomAmABusinessRule(),

                    CustomerNameShouldNotBeEmpty.WhichAlwaysRaiseExceptionWithMessage(valueCanNotBeNull)
                });
        var result = action.Should().Throw<DomainValidationException>();
            
    }

    public class CustomAmABusinessRule : IAmABusinessRule
    {
        public CustomAmABusinessRule()
        {
        }

        public bool IsPassed()
        {
            return false;
        }

        public string GetViolationRuleMessage()
        {
            return "some error message";
        }
    }
}