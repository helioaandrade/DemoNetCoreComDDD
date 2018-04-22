
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Infra.Ioc;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Microsoft.Extensions.Options;

namespace InfraTest.Repositories
{
        public class RepositoryTestBase<T>
    {
        public T _repostiory = StartUp.Ioc.GetRequiredService<T>();

    


    }
}
