using System.Collections.Generic;

  namespace Poc.DemoNetCore.Domain.Core.Repositories.Base 
{
    public interface ILeitura<T>
    {
        List<T> List();

        T Get(int id);
    }
}
