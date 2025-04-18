namespace Quantum.Domain;

public interface IsAnIdentity;
public abstract class IsAnIdentity<T> : IsAValueObject<T>, IsAnIdentity
{
    public override string ToString()
    {
        var result = $"{typeof(T).Name}";
        foreach (var equalityComponent in GetEqualityComponents())
        {
            result += $" - {equalityComponent}";
        }

        return result.TrimEnd();
    }
}