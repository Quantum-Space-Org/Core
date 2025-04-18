using System.Linq;
using System.Text;
using Quantum.Core;

namespace Quantum.Domain.BusinessRule;

public static class ABusinessRuleExtensions
{
    public static void AssertThatIsValid(this IAmABusinessRule aBusinessRule)
    {
        if (This.Is.False(aBusinessRule.IsPassed()))
        {
            var violationRuleMessage = aBusinessRule.GetViolationRuleMessage();
            throw new DomainValidationException(ValidationResult.Fail(Result.Fail(violationRuleMessage)));
        }
    }
    public static void AssertThatAreValid(this List<IAmABusinessRule> businessRules)
    {
        var stringBuilder = new StringBuilder();

        foreach (var businessRule in businessRules.Where(businessRule => !This.Is.True(businessRule.IsPassed())))
        {
            stringBuilder.Append(businessRule.GetViolationRuleMessage());
            stringBuilder.AppendLine();
        }

        if (!string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        {
            throw new DomainValidationException(ValidationResult.Fail(Result.Fail(stringBuilder.ToString())));
        }
    }
}