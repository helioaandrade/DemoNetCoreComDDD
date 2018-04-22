using AutoMapper;
using Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;

namespace Poc.DemoNetCore.Domain.Core.Mapper
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaInputCommand>();
            CreateMap<CalculoHistoricoLog, CalculoHistoricoLogInputCommand>();
        }
    }
}
