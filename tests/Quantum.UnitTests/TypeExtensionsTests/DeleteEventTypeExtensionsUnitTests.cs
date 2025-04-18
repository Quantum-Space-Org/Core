using Quantum.Core;
using Quantum.Domain.Messages.Event;

namespace Quantum.UnitTests.TypeExtensionsTests;

public class DeleteEventTypeExtensionsUnitTests : DeleteEvent
{
    [Fact]
    public void TestIsChildOf()
        => this.GetType().AssemblyQualifiedName.IsChildOf<DeleteEvent>().Should().BeTrue();

    [Fact]
    public void TestIsADeleteDomainEventEvent()
        => this.GetType().AssemblyQualifiedName.IsADeleteDomainEventEvent().Should().BeTrue();

    public DeleteEventTypeExtensionsUnitTests(string aggregateId) : base(aggregateId)
    {
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return AggregateId;
    }
}