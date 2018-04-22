using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Tests
{
  public  class TestBase : AutofacTestFramework
    {
      public readonly LinkedContext Context;
        public TestBase()
        {
            Context = new LinkedContext(@"Data source =\\10.10.10.2\\Iterative\\Projetos\\Linked Gourmet\\BaseDadosDev\\linked.db");
            
        }
        public void Dispose()
        {
        }
    }
}
