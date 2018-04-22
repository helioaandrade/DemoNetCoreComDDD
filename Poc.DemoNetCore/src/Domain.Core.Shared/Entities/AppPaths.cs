using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Poc.DemoNetCore.Domain.Shared.Entities
{
    public class AppPaths
    {
        public string DiretorioFC { get => GetRoot() + @"LinkedGourmet\fc\"; }
        public string DiretorioAtual { get => GetDiretorioAtual(); }
        public string BancoDados { get => GetRoot() + @"LinkedGourmet\fc\db\"; }
        public string ConfigPath { get => GetConfigPath(); }
        public string ConsoleDownloaderOutPutFile { get => GetRoot() + @"Download_versoes\"; }
        public string RunnerPath { get => @"C:\Users\win\source\repos\RunnerFull\RunnerFull\bin\Debug\RunnerFull.exe"; }


        private string GetDiretorioAtual()
        {
            return Directory.GetCurrentDirectory();
        }

        private string GetRoot()
        {
            return Directory.GetCurrentDirectory().Substring(0, 3);
        }
        
        private string GetConfigPath()
        {
            string jsonPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bool achou = false;
            int i = 0;
            while (!achou || i == 10)
            {
                var directoryName = Path.GetDirectoryName(jsonPath);
                if (File.Exists(directoryName + @"\config.json"))
                {
                    achou = true;
                    jsonPath = directoryName + @"\config.json";
                    return jsonPath;
                }
                else
                {
                    jsonPath = directoryName;
                }
                i++;
            }
            return "erro";
        }
        
    }

    
}
