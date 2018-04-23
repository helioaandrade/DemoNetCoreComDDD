using AutoMapper;
using Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;

namespace Infra.Mapper
{
    public class Config
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Pessoa, PessoaInputCommand>();
            cfg.CreateMap<PessoaInputCommand, Pessoa>();

            cfg.CreateMap<CalculoHistoricoLog, CalculoHistoricoLogInputCommand>();
            cfg.CreateMap<CalculoHistoricoLogInputCommand, CalculoHistoricoLog>();
        }
    }
}
