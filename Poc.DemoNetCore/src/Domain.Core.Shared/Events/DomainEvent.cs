using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;
using System;

namespace Poc.DemoNetCore.Domain.Core.Shared.Events
{
    public static class DomainEvent
    {
        public static IServiceProvider Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(ICoreValidationHandler<T>));
                    ((ICoreValidationHandler<T>)obj).Handle(args);
                }
            }
            catch { }
        }
    }
}
