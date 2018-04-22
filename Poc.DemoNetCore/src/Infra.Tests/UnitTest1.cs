using System;
using System.Linq;
using LinkedGourmet.FrenteDeCaixa.Domain.Core.Shared.Entities;
using Microsoft.Extensions.Options;
using Xunit;

namespace Infra.Tests
{
    
    public class UnitTest1 : TestBase
    {
        public void Init()
        {
          
        }
        [Fact]
        public void Test1()
        {


            var a = Context.Redes.ToList();
        }
    }
}
