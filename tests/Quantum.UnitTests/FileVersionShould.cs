using Quantum.ProductInfo;

namespace Quantum.UnitTests;

public class FileVersionShould
{
    [Fact]
    public void test()
    {
        var version = ProductVersion.Version();
        version.Should().BeEquivalentTo("0.0.21.0");
    }
}