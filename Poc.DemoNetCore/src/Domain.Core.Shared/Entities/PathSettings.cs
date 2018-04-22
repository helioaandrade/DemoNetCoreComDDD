using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Shared.Entities
{
    public class PathSettings
    {
        public NFCESettings NFCESettings { get; set; }
    }
    public class NFCESettings
    {
        public string CaminhoFisicoCertificado { get; set; }
        public string ProcessoEmissao { get; set; }
        public string IndicadorPresenca { get; set; }
        public string OperacaoConsumidorFinal { get; set; }
        public string FinalidadeEmissao { get; set; }
        public string TipoOperacao { get; set; }
        public string IdentificadorDestino { get; set; }

        public string Modelo { get; set; }

        public string NaturezaOperacao { get; set; }

        public string IndicadorFormaPagamento { get; set; }

        public string TipoEmissao { get; set; }

        public string ValorItemCompoe { get; set; }

        public string ModalidadeFrete { get; set; }

        public string CaminhoEsquema { get; set; }
        public string CaminhoAssinada { get; set; }
        public string CaminhoArqRetorno { get; set; }
        public string VersaoQrCode { get; set; }
    }
}
