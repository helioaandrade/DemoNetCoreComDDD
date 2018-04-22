using System;

namespace Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
