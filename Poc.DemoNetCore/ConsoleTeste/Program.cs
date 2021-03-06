﻿using System;
using RestSharp;


namespace ConsoleTeste
{
    class Program
    {
        private const string TRACO = "--------------------------------------------------------------";

        static void Main(string[] args)
        {
            string URL_BASE = ConstantesHelper.URL_BASE_LOCALIZACAO;
            RestClient client = new RestClient(URL_BASE);
            RestRequest request = new RestRequest();

            try
            {
                #region Chamada API LISTA_PESSOAS

                var listaPessoas = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_LISTAR_PESSOAS, Method.GET);

                Console.WriteLine(MostrarTitulo("Lista de Pessoas Cadastradas"));
                Console.WriteLine(listaPessoas.Content);
                Console.WriteLine(TRACO);

                #endregion

                #region Chamada API LISTA_HISTORICO_LOG

                var historicos = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_HISTORICO_LOG, Method.GET);

                Console.WriteLine(MostrarTitulo("Lista de Históricos de Cálculos"));
                Console.WriteLine(historicos.Content);
                Console.WriteLine(TRACO);

                #endregion

                #region Chamada API LISTA_AMIGOS_MAIS_PROXIMOS
                string nome = "helio";
                string recurso = string.Format("/AmigosMaisProximos/Listar/{0}", nome);

                var amigosProximos = ChamarApi(URL_BASE, recurso, Method.GET);

                Console.WriteLine(MostrarTitulo("Lista de Amigos Mais Próximos do helio"));
                Console.WriteLine(amigosProximos.Content);
                Console.WriteLine(TRACO);

                #endregion

                #region Chamada API LISTA_AMIGOS_MAIS_PROXIMOS_POR_PESSOA

                var amigosProximosPorPessoa = ChamarApi(URL_BASE, ConstantesHelper.RECURSO_AMIGOS_MAIS_PROXIMOS_POR_PESSOA, Method.GET);

                Console.WriteLine(MostrarTitulo("Lista de Amigos Mais Próximos de Cada Pessoa"));
                Console.WriteLine(amigosProximos.Content);
                Console.WriteLine(TRACO);

                #endregion

                #region Chamada API RECURSO_INCLUIR_PESSOA

                // TODO: Console API RECURSO_INCLUIR_PESSOA

                //object dadosPessoa = new { nome = "nome 1", latitude = -23.1, longitude = 46.1 };

                //var inclusaoPessoa = ChamarApiPost(URL_BASE, ConstantesHelper.RECURSO_INCLUIR_PESSOA, dadosPessoa);

                //Console.WriteLine(MostrarTitulo("Inclusao de Pessoa"));
                //Console.WriteLine(inclusaoPessoa.Content);
                //Console.WriteLine(TRACO);

                #endregion

                #region Chamada API RECURSO_INCLUIR_HISTORICO_LOG

                // TODO: Console APIRECURSO_INCLUIR_HISTORICO_LOG

                //object dadosHistorico = new {  pessoaOrigemID = 1, pessoaDestinoID = 2 , distancia=10};
                 
                //var inclusaoHistorico = ChamarApiPost(URL_BASE, ConstantesHelper.RECURSO_INCLUIR_HISTORICO_LOG, dadosHistorico);

                //Console.WriteLine(MostrarTitulo("Inclusao de Histórico de Log"));
                //Console.WriteLine(inclusaoHistorico.Content);
                //Console.WriteLine(TRACO);

                #endregion

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha:" + ex.Message);
            }

        }

        public static IRestResponse ChamarApi(string urlBase, string recurso, RestSharp.Method metodo)
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

        public static IRestResponse ChamarApiPost(string urlBase, string recurso, object dados)
        {
            try
            {
                string URL_BASE = ConstantesHelper.URL_BASE_LOCALIZACAO;

                RestClient client = new RestClient(URL_BASE);

                RestRequest request = new RestRequest(recurso, Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(dados);

                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na chamada da API - " + ex.Message);
            }

        }
        public static string MostrarTitulo(string titulo)
        {
            return string.Format("----- [{0}] -------------------------------------)", titulo);
        }


    }



    public static class ConstantesHelper
    {
        public const string URL_BASE_LOCALIZACAO = @"http://localhost:8090/api/GeoLocalizacao/";

        public const string RECURSO_AMIGOS_MAIS_PROXIMOS = @"AmigosMaisProximos/Listar/";
        public const string RECURSO_AMIGOS_MAIS_PROXIMOS_POR_PESSOA = @"AmigosMaisProximosPorPessoa/Listar/";
        public const string RECURSO_LISTAR_PESSOAS = @"ListarPessoas/";
        public const string RECURSO_HISTORICO_LOG = @"HistoricosLog/Listar";
        public const string RECURSO_INCLUIR_PESSOA = @"Pessoa/Incluir/";
        public const string RECURSO_INCLUIR_HISTORICO_LOG = @"Pessoa/Incluir";

    }
}
