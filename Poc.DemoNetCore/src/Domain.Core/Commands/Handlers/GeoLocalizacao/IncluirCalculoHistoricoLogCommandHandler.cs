using Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Commands.Results.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Commands.Handlers.GeoLocalizacao
{
    public class IncluirCalculoHistoricoLogCommandHandler : ICommandHandler<CalculoHistoricoLogInputCommand>
    {
        public ICommandResult Handle(CalculoHistoricoLogInputCommand command)
        {
            try
            {

                return new CalculoHistoricoLogCommandResult("Inclusao de pessoa realizada com sucesso",
                                                                   command.PessoaDestinoID,
                                                                   command.PessoaDestinoID,
                                                                   command.Distancia);


            }
            catch (Exception ex)
            {

                return new CalculoHistoricoLogCommandResult("Inclusao de pessoa realizada com sucesso", false);
            }
        }
    }
}
