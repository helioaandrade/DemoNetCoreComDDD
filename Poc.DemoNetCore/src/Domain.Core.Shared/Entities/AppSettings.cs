
using System;
using System.IO;

namespace Poc.DemoNetCore.Domain.Core.Shared.Entities
{
    public class AppSettings
    {
        private string _databasePath;

        public string DatabasePath
        {
            get { return PathDatabase(_databasePath); }
            set { _databasePath = value; }
        }
        public static string SolutionPath()
        {
             var solutionName = "Poc.DemoNetCore";
            
            var path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("Poc.DemoNetCore"));
            return $"{path}{solutionName}";
         }

        public static string PathContent(string module)
        {
            var path = Directory.GetCurrentDirectory();

            Console.WriteLine("PathContent" + path);
            return path;
         }

        public static string PathDatabase(string databaseName)
        {
            var solutionName = "Poc.DemoNetCore";
            var path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("Poc.DemoNetCore"));
            var pathBase = $"{path}{solutionName}\\db\\";

            var retorno = pathBase + $@"{databaseName}";
            Console.WriteLine("PathDataBase" + retorno);
            return retorno;
        }


    }
}
