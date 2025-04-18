namespace Quantum.CorrelationId;

public interface ICorrelationId
{
    string GetCorrelationId();
}

public class CorrelationId(IHttpContextAccessor contextAccessor) : ICorrelationId
{
    public string GetCorrelationId()
        => contextAccessor.GetCorrelationId();
}