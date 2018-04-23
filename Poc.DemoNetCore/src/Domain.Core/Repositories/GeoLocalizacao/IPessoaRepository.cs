using Poc.DemoNetCore.Domain.Core.Dto;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao
{
    public interface IPessoaRepository :
         IGravacao<Pessoa>
       , IPesquisa<Pessoa>
       , ILeitura<Pessoa>
    {
        List<Tracking> ObterAmigosMaisProximo(string Nome);
        List<LocalizacaoAmigos> ObterAmigosMaisProximoPorPessoa();
    }
}
