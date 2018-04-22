using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Utils.AppSettings
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string IssuerSigningKey { get; set; }
    }
}
