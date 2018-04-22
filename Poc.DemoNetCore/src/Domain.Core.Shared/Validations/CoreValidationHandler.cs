using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poc.DemoNetCore.Domain.Core.Shared.Validations
{
    public class CoreValidationHandler : ICoreValidationHandler<CoreNotification>
    {
        private List<CoreNotification> _notifications;

        public CoreValidationHandler()
        {
            _notifications = new List<CoreNotification>();
        }

        public void AddNotifications(string message)
        {
            _notifications.Add(new CoreNotification(message));
        }

        public void Dispose()
        {
            _notifications = new List<CoreNotification>();
        }

        public void Handle(CoreNotification args)
        {
            throw new NotImplementedException();
        }

        public bool HasNotifications()
        {
            const int VALOR_VALIDO_PARA_EXISTIR_NOTIFICACAO = 0;
            return _notifications.Count() != VALOR_VALIDO_PARA_EXISTIR_NOTIFICACAO;
        }

        public IEnumerable<CoreNotification> GetNotify()
        {
            return _notifications;
        }
    }
}
