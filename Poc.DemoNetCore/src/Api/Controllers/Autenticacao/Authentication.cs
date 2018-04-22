
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers.Autenticacao
{
    public class Authentication
    {
        public string Token { get; set; }

        public Authentication(string UrlApi)
        {
            _urlApi = UrlApi;

            this.Token = this.AutenticarApi(UrlApi);
        }

        private string AutenticarApi(string UrlApi)
        {
            try
            {

                var ret = string.Empty;
                var login = "admin";
                var senha = "admin";
 
                var client = new RestClient(UrlApi + "/Token");
                var request = new RestRequest { Method = Method.POST };

                var param = string.Format("grant_type=password&username={0}&password={1}", login, senha);

                request.Parameters.Clear();
                request.AddParameter("application/x-www-form-urlencoded", param, ParameterType.RequestBody);
                request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);

                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    dynamic obj = JsonConvert.DeserializeObject<object>(response.Content);

                    ret = obj["access_token"];
                }
 
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 

        private static string _urlApi;
      
        private static Authentication _autenticacao;

        public static Authentication Autenticacao
        {
            get
            {
                if (_autenticacao == null || _autenticacao.Token == null)
                {
                    lock (typeof(Authentication))
                    {
                        if (_autenticacao == null || _autenticacao.Token == null)
                            _autenticacao = new Authentication(_urlApi);
                    }
                }

                return _autenticacao;

            }
        }

        public void LimparTokenExpirado()
        {
            this.Token = null;
        }
    }
}
