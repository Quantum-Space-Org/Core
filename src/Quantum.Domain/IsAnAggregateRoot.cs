using System.Collections.Immutable;
using Quantum.Domain.Messages.Event;

namespace Quantum.Domain;

public abstract class IsAnAggregateRoot : IsAnEntity, IQueueEvent
{
    private object _snapshot;
    private readonly DomainEventQueue _domainEventQueue = new();

    public void Queue(IsADomainEvent @event)
        => _domainEventQueue.Queue(@event);

    public void Queue(params IsADomainEvent[] @events) => _domainEventQueue.Queue(@events);

    public ImmutableList<IsADomainEvent> DeQueueDomainEvents() => _domainEventQueue.DeQueueDomainEvents();

    public ImmutableList<IsADomainEvent> GetQueuedDomainEvents() => _domainEventQueue.GetQueuedDomainEvents();

    protected void Apply(IsADomainEvent @event)
    {
        Mutate(@event);
        Queue(@event);
    }

    protected void Apply(Queue<IsADomainEvent> @events)
    {
        foreach (var @event in @events) Apply(@event);
    }

    protected virtual void Mutate(IsADomainEvent @event)
    {
    }

    protected void SaveSnapshot(object snapShot)
        => _snapshot = snapShot;

    protected T TakeSnapshot<T>()
    {
        if (_snapshot != null)
            return (T)_snapshot;

        return default(T);
    }
}

public abstract class IsAnAggregateRoot<TIdentity>(TIdentity identity)
    : IsAnEntity<TIdentity>(identity), IQueueEvent
    where TIdentity : IsAnIdentity<TIdentity>
{
    private DomainEventQueue _domainEventQueue = new DomainEventQueue();

    private object _snapshot;

    public void Queue(IsADomainEvent @event)
        => _domainEventQueue.Queue(@event);

    public void Queue(params IsADomainEvent[] @events) => _domainEventQueue.Queue(@events);

    public ImmutableList<IsADomainEvent> DeQueueDomainEvents() => _domainEventQueue.DeQueueDomainEvents();

    public ImmutableList<IsADomainEvent> GetQueuedDomainEvents() => _domainEventQueue.GetQueuedDomainEvents();

    protected void Apply(IsADomainEvent @event)
    {
        Mutate(@event);
        Queue(@event);
    }

    protected void Apply(Queue<IsADomainEvent> @events)
    {
        foreach (var @event in @events) Apply(@event);
    }

    protected virtual void Mutate(IsADomainEvent @event)
    {
    }

    protected void SaveSnapshot(object snapShot)
        => _snapshot = snapShot;

    protected T TakeSnapshot<T>()
    {
        if (_snapshot != null)
            return (T)_snapshot;

        return default(T);
    }
}