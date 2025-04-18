using Quantum.Core;

namespace Quantum.Domain.Messages.Event;

public static class DeleteEventExtensions
{
    public static bool IsADeleteDomainEventEvent(this string domainEventQualifiedName)
        => !string.IsNullOrWhiteSpace(domainEventQualifiedName) && domainEventQualifiedName.IsChildOf<DeleteEvent>();
}