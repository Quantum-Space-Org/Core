namespace Quantum.Domain.BusinessRule;

public interface IAmABusinessRule
{
    bool IsPassed();

    string GetViolationRuleMessage();
}