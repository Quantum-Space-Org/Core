namespace Quantum.Domain.Messages.Event;

public abstract class DeleteEvent(string aggregateId) : IsADomainEvent(aggregateId);