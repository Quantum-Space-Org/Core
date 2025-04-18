using System.Collections.Immutable;
using Quantum.Domain.Messages.Event;

namespace Quantum.Domain;

public interface IQueueEvent
{
    void Queue(IsADomainEvent @event);
    void Queue(params IsADomainEvent[] @events);
    ImmutableList<IsADomainEvent> DeQueueDomainEvents();
    ImmutableList<IsADomainEvent> GetQueuedDomainEvents();
}

public class DomainEventQueue : IQueueEvent
{
    private readonly Queue<IsADomainEvent> _queuedDomainEvents = new();

    public void Queue(IsADomainEvent @event)
        => _queuedDomainEvents.Enqueue(@event);

    public void Queue(params IsADomainEvent[] @events)
    {
        foreach (var @event in @events) _queuedDomainEvents.Enqueue(@event);
    }

    public ImmutableList<IsADomainEvent> DeQueueDomainEvents()
    {
        var result = _queuedDomainEvents.ToImmutableList();
        EmptyQueue();
        return result;
    }

    public ImmutableList<IsADomainEvent> GetQueuedDomainEvents()
        => _queuedDomainEvents.ToImmutableList();


    private void EmptyQueue() => _queuedDomainEvents.Clear();
}