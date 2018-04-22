using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Core.Dto
{
    public class Tracking
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public double Distancia { get; set; }
    }

    public class Localizacao
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocalizacaoAmigos
    {
        public PessoaOrigem Amigo { get; set; }
        public List<Tracking> ListaAmigosProximos { get; set; }
    }

    public class PessoaOrigem
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
    }
}
