using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;

namespace Poc.DemoNetCore.Domain.Core.Shared.Validations
{
    public sealed class ContainerEvents
    {
        public ICoreValidationHandler<CoreNotification> container;
    }
}
