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
    public class IncluirPessoaCommandHandler : ICommandHandler<PessoaInputCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public IncluirPessoaCommandHandler(IPessoaRepository pessoaRepository_, IMapper map_)
        {
            _pessoaRepository = pessoaRepository_;
            _mapper = map_;
        }

        public ICommandResult Handle(PessoaInputCommand command)
        {
            var pessoa_ = _mapper.Map<PessoaInputCommand, Pessoa>(command);

            if (!pessoa_.IsValid)
                return null;

            try
            {
                var pessoa = AutoMapper.Mapper.Map<Pessoa, Pessoa>(pessoa_);

                var novapessoa = _pessoaRepository.Save(pessoa);

                return new PessoaCommandResult("Inclusao de pessoa realizada com sucesso",
                                                novapessoa.Id,
                                                command.Nome,
                                                command.Latitude,
                                                command.Longitude);

            }
            catch (Exception ex)
            {
                 return new PessoaCommandResult("Não foi possível efetuar inclusão da pessoa - " + ex.Message, false);
            }
        }
    }
}
