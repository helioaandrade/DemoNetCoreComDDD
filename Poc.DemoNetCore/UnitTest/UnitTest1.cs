
using UnitTest;
using NUnit.Framework;
using RestSharp;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{

    [TestClass]
    public class UnitTest1
    {
        private const string URL_BASE = ConstantesHelper.URL_BASE_LOCALIZACAO;
        RestClient client = new RestClient(URL_BASE);
        RestRequest request = new RestRequest();

        // Atenção: A API deve está rodando para fazer os testes!!

        [TestMethod, Order(1)]
        public void Teste_Lista_Pessoas()
        {
            try
            {
                // Ação 
                var response = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_LISTAR_PESSOAS, Method.GET);

                // Validação
                bool result = !String.IsNullOrEmpty(response.Content);

                NUnit.Framework.Assert.True(result);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                NUnit.Framework.Assert.True(false);
            }

        }

        [TestMethod, Order(2)]
        public void Teste_Historicos_Log()
        {
            try
            {
                // Ação 
                var response = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_HISTORICO_LOG, Method.GET);

                // Validação
                bool result = !String.IsNullOrEmpty(response.Content);

                NUnit.Framework.Assert.True(result);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                NUnit.Framework.Assert.True(false);
            }

        }

        [TestMethod, Order(3)]
        public void Teste_Obter_Meus_Amigos_Mais_Proximos()
        {
            try
            {
                // Ação 
                var response = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_AMIGOS_MAIS_PROXIMOS, Method.GET);

                // Validação
                bool result = !String.IsNullOrEmpty(response.Content);

                NUnit.Framework.Assert.True(result);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                NUnit.Framework.Assert.True(false);
            }
        }

        [TestMethod, Order(3)]
        public void Teste_Obter_Amigos_Mais_Proximos_De_Cada_Pessoa()
        {
            try
            {
                // Ação 
                var response = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_AMIGOS_MAIS_PROXIMOS_DE_CADA_PESSOA, Method.GET);

                // Validação
                bool result = !String.IsNullOrEmpty(response.Content);

                NUnit.Framework.Assert.True(result);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                NUnit.Framework.Assert.True(false);
            }
        }

        [TestMethod, Order(3)]
        public void Teste_Incluir_Pessoas()
        {
            // TODO: Teste_Incluir_Pessoas()
            //try
            //{
            //    // Ação 
            //    var response = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_INCLUIR_PESSOA, Method.POST);

            //    // Validação
            //    bool result = !String.IsNullOrEmpty(response.Content);

            //    NUnit.Framework.Assert.True(result);
            //}
            //catch (Exception ex)
            //{
            //    string erro = ex.Message;
            //    NUnit.Framework.Assert.True(false);
            //}
        }

        [TestMethod, Order(5)]
        public void Teste_Incluir_Historico_Log()
        {
            // TODO Teste_Incluir_Historico_Log()
            //try
            //{
            //    // Ação 
            //    var response = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_INCLUIR_HISTORICO_LOG, Method.POST);

            //    // Validação
            //    bool result = !String.IsNullOrEmpty(response.Content);

            //    NUnit.Framework.Assert.True(result);
            //}
            //catch (Exception ex)
            //{
            //    string erro = ex.Message;
            //    NUnit.Framework.Assert.True(false);
            //}
        }

        public IRestResponse ChamarApi(string urlBase, string recurso, RestSharp.Method metodo)
        {
            try
            {
                string URL_BASE = ConstantesHelper.URL_BASE_LOCALIZACAO;

                RestClient client = new RestClient(URL_BASE);

                RestRequest request = new RestRequest(recurso, metodo);

                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na chamada da API - " + ex.Message);
            }

        }

    }

    public static class ConstantesHelper
    {
        public const string URL_BASE_LOCALIZACAO = @"http://localhost:8090/api/GeoLocalizacao/";

        public const string RECURSO_AMIGOS_MAIS_PROXIMOS = @"AmigosMaisProximos/Listar/";

        public const string RECURSO_AMIGOS_MAIS_PROXIMOS_DE_CADA_PESSOA = @"AmigosMaisProximosPorPessoa/Listar/";
        public const string RECURSO_LISTAR_PESSOAS = @"ListarPessoas/";
        public const string RECURSO_HISTORICO_LOG = @"HistoricosLog/Listar";
        public const string RECURSO_INCLUIR_PESSOA = @"Pessoa/Incluir/";
        public const string RECURSO_INCLUIR_HISTORICO_LOG = @"Pessoa/Incluir";

    }
}
