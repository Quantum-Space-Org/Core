using Quantum.UnitTests.Domain.TestSpecificClasses;

namespace Quantum.UnitTests.Domain;

public class EntityTests
{
    [Fact]
    public void TestEntityEquality()
    {
        FakeEntityIdentity isAnIdentity = new FakeEntityIdentity(1);

        IsAnEntity fakeEntity1 = new FakeEntity(isAnIdentity, "value1");
        IsAnEntity fakeEntity2 = new FakeEntity(isAnIdentity, "value2");

        Assert.Equal(fakeEntity1, fakeEntity2);
        Assert.True(fakeEntity1.Equals(fakeEntity2));
        Assert.True(fakeEntity1 == fakeEntity2);
    }

    [Fact]
    public void TestAggregateRootEquality()
    {
        
        IsAnAggregateRoot fakeEntity1 = new FakeAggregateRootEntity("1", "value1");
        IsAnAggregateRoot fakeEntity2 = new FakeAggregateRootEntity("1", "value2");

        Assert.Equal(fakeEntity1, fakeEntity2);
        Assert.True(fakeEntity1.Equals(fakeEntity2));
        Assert.True(fakeEntity1 == fakeEntity2);
    }

    [Fact]
    public void TestGenericAggregateRootEquality()
    {
        FakeEntityIdentity isAnIdentity = new FakeEntityIdentity(1);

        IsAnAggregateRoot<FakeEntityIdentity> fakeEntity1 = new FakeGenericAggregateRootEntity(isAnIdentity, "value1");
        IsAnAggregateRoot<FakeEntityIdentity> fakeEntity2 = new FakeGenericAggregateRootEntity(isAnIdentity, "value2");

        Assert.Equal(fakeEntity1, fakeEntity2);
        Assert.True(fakeEntity1.Equals(fakeEntity2));
        Assert.True(fakeEntity1 == fakeEntity2);
    }


    [Fact]
    public void TestGenericEntityEquality()
    {
        FakeEntityIdentity isAnIdentity = new FakeEntityIdentity(1);

        IsAnEntity<FakeEntityIdentity> fakeEntity1 = new FakeGenericEntity(isAnIdentity, "value1");
        IsAnEntity<FakeEntityIdentity> fakeEntity2 = new FakeGenericEntity(isAnIdentity, "value2");

        Assert.Equal(fakeEntity1, fakeEntity2);
        Assert.True(fakeEntity1.Equals( fakeEntity2));
        Assert.True(fakeEntity1 == fakeEntity2);
    }

    [Fact]
    public void TestEntityEqualWithNull()
    {
        FakeEntityIdentity isAnIdentity = new FakeEntityIdentity(1);

        IsAnEntity<FakeEntityIdentity> fakeEntity1 = new FakeGenericEntity(isAnIdentity, "value1");

        Assert.False(fakeEntity1.Equals(null));

        fakeEntity1.Should().NotBe(null);
    }
}