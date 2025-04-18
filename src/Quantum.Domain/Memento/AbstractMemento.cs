using System.Collections.Immutable;
using Quantum.Domain.Messages.Event;

namespace Quantum.Domain.Memento;

public abstract class AbstractMemento : IQueueEvent
{
    private readonly Queue<IsADomainEvent> _eventQueue = new();
    private readonly DomainEventQueue _domainEventQueue = new();
    public void Queue(IsADomainEvent @event)
        => _domainEventQueue.Queue(@event);

    public void Queue(params IsADomainEvent[] @events) => _domainEventQueue.Queue(@events);

    public ImmutableList<IsADomainEvent> DeQueueDomainEvents() => _domainEventQueue.DeQueueDomainEvents();

    public ImmutableList<IsADomainEvent> GetQueuedDomainEvents() => _domainEventQueue.GetQueuedDomainEvents();


    private void EmptyQueue() => _eventQueue.Clear();
}