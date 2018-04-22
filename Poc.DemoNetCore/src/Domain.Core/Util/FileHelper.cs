using System;
using System.Globalization;
using System.IO;
using System.Text;



namespace Poc.DemoNetCore.Domain.Core.Util
{
    public static class FileHelper
    {

        /// <summary>
        /// ObterConteudo
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <param name="nomeArquivo"></param>
        /// <returns></returns>
        public static String ObterConteudo(string caminhoArquivo, string nomeArquivo)
        {
            var caminhoCompleto = string.Format(@"{0}\{1}", caminhoArquivo, nomeArquivo);
            return File.ReadAllText(caminhoCompleto);
        }

        /// <summary>
        /// SalvarConteudo
        /// </summary>
        /// <param name="caminhoArquivo"></param>
        /// <param name="nomeArquivo"></param>
        /// <param name="conteudo"></param>
        public static void SalvarConteudo(string caminhoArquivo, string nomeArquivo, string conteudo)
        {
            var caminhoCompleto = string.Format(@"{0}\{1}", caminhoArquivo, nomeArquivo);
            File.WriteAllText(caminhoCompleto, conteudo);
        }

        /// <summary>
        /// Retira Acento 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RetiraAcento(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
