using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;
using Poc.DemoNetCore.Domain.Core.Shared.Validations;
using Infra.Transactions;
using Poc.DemoNetCore.Domain.Core.Shared.Events;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers.Base
{
    [EnableCors("Cors")]
    public class BaseController : Controller
    {
        private ICoreValidationHandler<CoreNotification> _notifications;
        protected readonly Uow _uow;
        public HttpResponseMessage ResponseMessage;

        public BaseController(Uow uow_)
        {
            _uow = uow_;
        }

        public BaseController() { }

        public async Task<IActionResult> Response(object result)
        {
            try
            {
                _notifications = DomainEvent.Container.GetService<ICoreValidationHandler<CoreNotification>>();
                if (_notifications != null)
                {
                    if (!_notifications.HasNotifications())
                    {
                        try
                        {
                            if (_uow != null)
                                _uow.Commit();

                            return Ok(new
                            {
                                success = true,
                                data = result
                            });
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(new
                            {
                                success = false,
                                errors = new[] { "Erro ao buscar dados do Servidor, EX:" + ex.Message }
                            });
                        }
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            success = false,
                            errors = new[] { _notifications.GetNotify() }
                        });
                    }
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Erro ao buscar dados do Servidor" }
                    });
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { "Erro ao buscar dados do Servidor, EX:" + ex.Message }
                });
            }
        }

        public async Task<IActionResult> ResponseOk(object data)
        {
            return Ok(new
            {
                success = true,
                data
            });
        }

       

        protected override void Dispose(bool disposing)
        {
            if (_notifications != null)
                _notifications.Dispose();

            if (_uow != null)
                _uow.Dispose();
        }
    }
}