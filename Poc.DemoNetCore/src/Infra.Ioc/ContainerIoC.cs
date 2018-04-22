using System;
using Infra.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Poc.DemoNetCore.Domain.Core.Shared.Validations.Contracts;
using Poc.DemoNetCore.Domain.Core.Shared.Validations;
using Poc.DemoNetCore.Domain.Core.Shared.Events;
using System.ComponentModel;
using Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao;
using Infra.Repositories.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Commands.Handlers.GeoLocalizacao;
using Infra.Utils.AppSettings;

namespace Infra.Ioc
{
    public class ContainerIoC
    {
        public static void Register(IServiceCollection services)
        {
            //transactions
            services.AddTransient<Uow, Uow>();
            services.AddTransient<DemoContext, DemoContext>();

            services.AddScoped<Uow, Uow>();
            services.AddDbContext<DemoContext>();

            //Notifications
            services.AddScoped<ICoreValidationHandler<CoreNotification>, CoreValidationHandler>();

            // Repositórios
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ICalculoHistoricoLogRepository, CalculoHistoricoLogRepository>();

            // Handlers
            services.AddTransient<IncluirPessoaCommandHandler, IncluirPessoaCommandHandler>();
            services.AddTransient<IncluirCalculoHistoricoLogCommandHandler, IncluirCalculoHistoricoLogCommandHandler>();
  

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            DomainEvent.Container = serviceProvider;
        }
    }
}
