using System;
using System.Collections.Generic;

namespace Quantum.Resolver;

public interface IResolver
{
    T Resolve<T>();
    object Resolve(Type type);
    IEnumerable<T> ResolveAll<T>();
}