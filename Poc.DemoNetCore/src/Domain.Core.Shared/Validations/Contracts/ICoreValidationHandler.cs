using System;
using System.Collections.Generic;

namespace Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts
{
    public interface ICoreValidationHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> GetNotify();
        bool HasNotifications();
        void AddNotifications(string message);
    }
}
