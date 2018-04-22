using Poc.DemoNetCore.Domain.Core.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Commands.Results.GeoLocalizacao
{
    public class PessoaCommandResult : ICommandResult
    {
        #region Propriedades
        public bool Sucesso { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public string Resultado { get; set; }

        #endregion

        public PessoaCommandResult()
        {
        }

        public PessoaCommandResult(string resultado)
        {
            Sucesso = true;
            Resultado = resultado;
        }

        public PessoaCommandResult(string resultado, bool sucesso)
        {
            Sucesso = sucesso;
            Resultado = resultado;
        }


        public PessoaCommandResult(string resultado, int id, string nome, decimal latitude, decimal longitude)
        {
            Resultado = resultado;
            Id = id;
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
            Sucesso = true;
        }

    }
}
