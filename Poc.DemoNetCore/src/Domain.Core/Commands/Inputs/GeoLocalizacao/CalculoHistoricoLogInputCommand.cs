using Poc.DemoNetCore.Domain.Core.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao
{
    public class CalculoHistoricoLogInputCommand : ICommand
    {
        #region Propriedades
        public int PessoaOrigemID { get; set; }
        public int PessoaDestinoID { get; set; }
        public decimal Distancia { get; set; }
   
        #endregion

    }
}
