using Poc.DemoNetCore.Domain.Core.Shared.Commands;

namespace Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao
{
    public class PessoaInputCommand : ICommand
    {

        #region Propriedades
        public string Nome { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        #endregion



    }
}
