using Quantum.Core;

namespace Quantum.Domain;

public class DomainValidationException(ValidationResult validationResult): Exception
{
    public ValidationResult ValidationResult { get; } = validationResult;
}