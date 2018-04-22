using Poc.DemoNetCore.Domain.Core.Shared.Events;
using Poc.DemoNetCore.Domain.Core.Shared.Validations;
using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Poc.DemoNetCore.Domain.Core.Validations
{
    public abstract class ValidationBase
    {
        protected ICoreValidationHandler<CoreNotification> _notifications;

        protected ValidationBase()
        {
            ContainerEvents containerEvents = new ContainerEvents();
            containerEvents.container = DomainEvent.Container.GetService<ICoreValidationHandler<CoreNotification>>();
            _notifications = containerEvents.container;
        }
    }
}
