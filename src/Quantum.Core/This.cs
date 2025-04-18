using System.Collections.Generic;
using System.Linq;

namespace Quantum.Core;

public class This
{
    public static This Is
        => new This();

    public bool False(bool value)
        => false == value;

    public bool True(bool value)
        => true == value;

    public bool Null(object obj)
        => obj == default;

    public bool NullOrEmpty<T>(ICollection<T> collection)
        => collection == null || !collection.Any();
}