namespace Quantum.Domain.Messages.Event;

public interface DomainEvent;

public abstract class IsADomainEvent 
    : IsAValueObject<IsADomainEvent>, DomainEvent
{
    public string AggregateId { get; set; }
    public MessageMetadata MessageMetadata { get; set; }

    protected IsADomainEvent(string aggregateId)
    {
        AggregateId = aggregateId;
        MessageMetadata = new MessageMetadata($"evnt-{Guid.NewGuid()}", GetType().AssemblyQualifiedName);
    }

    public string GetId() 
        => MessageMetadata.Id;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return AggregateId;
    }
}