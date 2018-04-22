using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Poc.DemoNetCore.Domain.Shared.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            WebHost.CreateDefaultBuilder()
            .UseContentRoot(AppSettings.PathContent("api"))
            .UseUrls("http://*:8090")
    

           .UseStartup<Startup>().UseApplicationInsights()
           .Build().Run();
          
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
