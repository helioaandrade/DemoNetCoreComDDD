using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao
{
    public class Pessoa : Entity
    {
        #region Propriedades

        public string Nome { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        protected override bool Validate()
        {
            return true;
        }

        #endregion

    }
}
