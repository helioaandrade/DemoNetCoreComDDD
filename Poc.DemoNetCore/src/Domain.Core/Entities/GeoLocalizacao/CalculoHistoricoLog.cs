using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao
{
    public class CalculoHistoricoLog : Entity
    {

        #region Propriedades
        public int PessoaOrigemID { get; set; }
        public int PessoaDestinoID { get; set; }
        public decimal Distancia { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        #endregion

        protected override bool Validate()
        {
            return true;
        }

    }
}
