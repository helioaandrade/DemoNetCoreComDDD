using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Infra;
using Infra.Ioc;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace InfraTest
{
    [SetUpFixture]
    public class StartUp
    {
        [OneTimeSetUp]
        public void Up()
        {
            Db.Database.BeginTransaction();

        }
        [OneTimeTearDown]
        public void  Down()
        {
            Db.Database.RollbackTransaction();

        }
        public static IServiceProvider Ioc { get; } = InitIoc();
        public static DemoContext Db { get; } = Ioc.GetRequiredService<DemoContext>();


        private static IServiceProvider InitIoc()
        {
            var Services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var Configuration = builder.Build();
            ContainerIoC.Register(Services);

            Services.AddOptions();
            Services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

           
            return Services.BuildServiceProvider();

        }

        
    }

 
}
