using AutoMapper;
using Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Commands.Results.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Commands.Handlers.GeoLocalizacao
{
    public class IncluirCalculoHistoricoLogCommandHandler : ICommandHandler<CalculoHistoricoLogInputCommand>
    {
        private readonly ICalculoHistoricoLogRepository _calculoHistoricoLogRepository;
        private readonly IMapper _mapper;

        public IncluirCalculoHistoricoLogCommandHandler(ICalculoHistoricoLogRepository calculoHistoricoLogRepository_, IMapper map_)
        {
            _calculoHistoricoLogRepository = calculoHistoricoLogRepository_;
            _mapper = map_;
        }

        public ICommandResult Handle(CalculoHistoricoLogInputCommand command)
        {
            try
            {
                var historico_ = _mapper.Map<CalculoHistoricoLogInputCommand, CalculoHistoricoLog>(command);

                if (!historico_.IsValid)
                    return null;

                var historico = AutoMapper.Mapper.Map<CalculoHistoricoLog, CalculoHistoricoLog>(historico_);
 
                var novoHistorico = _calculoHistoricoLogRepository.Save(historico);

                return new CalculoHistoricoLogCommandResult("Inclusao de histórico realizada com sucesso",
                                                                   novoHistorico.Id,
                                                                   command.PessoaDestinoID,
                                                                   command.PessoaDestinoID,
                                                                   command.Distancia,
                                                                   novoHistorico.UltimaAtualizacao
                                                                   );

            }
            catch (Exception ex)
            {

                return new CalculoHistoricoLogCommandResult("Não foi possível incluir histórico - " + ex.Message, false);
            }

        }
    }
}
