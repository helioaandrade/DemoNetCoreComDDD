using Poc.DemoNetCore.Domain.Core.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Commands.Results.GeoLocalizacao
{
    public class CalculoHistoricoLogCommandResult : ICommandResult
    {
        #region Propriedades
        public bool Sucesso { get; set; }
        public int PessoaOrigemID { get; set; }
        public int PessoaDestinoID { get; set; }

        public decimal Distancia { get; set; }

        public string Resultado { get; set; }

        #endregion

        public CalculoHistoricoLogCommandResult()
        {
        }

        public CalculoHistoricoLogCommandResult(string resultado)
        {
            Sucesso = true;
            Resultado = resultado;
        }

        public CalculoHistoricoLogCommandResult(string resultado, bool sucesso)
        {
            Sucesso = sucesso;
            Resultado = resultado;
        }


        public CalculoHistoricoLogCommandResult(string resultado, int pessoaOrigemId, int pessoaDestino, decimal distancia)
        {
            Resultado = resultado;
            PessoaOrigemID = pessoaOrigemId;
            PessoaDestinoID = pessoaDestino;
            Distancia = distancia;

            Sucesso = true;
        }
    }
}
