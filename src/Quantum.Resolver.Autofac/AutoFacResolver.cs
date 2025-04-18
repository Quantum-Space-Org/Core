using System;
using System.Collections.Generic;
using Autofac;

namespace Quantum.Resolver.Autofac
{
    public class AutoFacResolver : IResolver
    {
        private readonly IContainer _container;

        public AutoFacResolver(IContainer container) => _container = container;

        public T Resolve<T>() => _container.Resolve<T>();

        public object Resolve(Type type) => _container.Resolve(type);
        public IEnumerable<T> ResolveAll<T>() => _container.Resolve<ICollection<T>>();
    }
}