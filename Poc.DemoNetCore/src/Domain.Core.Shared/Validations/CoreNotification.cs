using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;
using System;

namespace Poc.DemoNetCore.Domain.Core.Shared.Validations
{
    public class CoreNotification : IDomainEvent
    {
        public string Key { get; private set; }
        public string Message { get; private set; }
        public DateTime DateOccurred { get; private set; }


        public CoreNotification(string message)
        {
            this.Key = Guid.NewGuid().ToString();
            this.Message = message;
            this.DateOccurred = DateTime.Now;
        }
    }
}
