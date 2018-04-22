using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Infra.Ioc;
using Xunit.Ioc;
using Xunit.Ioc.Autofac;

namespace Infra.Tests
{
    public class AutofacContainerBootstrapper : IDependencyResolverBootstrapper
    {
        private static readonly object _lock = new object();
        private static IDependencyResolver _dependencyResolver;

        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            ContainerIoC.Register();
            builder.RegisterModule(new TestsModule(typeof(AutofacContainerBootstrapper).Assembly));

            return builder.Build();
        }

        public IDependencyResolver GetResolver()
        {
            lock (_lock)
            {
                if (_dependencyResolver == null)
                    _dependencyResolver = new AutofacDependencyResolver(CreateContainer());
                return _dependencyResolver;
            }
        }
    }
}
