using System.Collections.Generic;

namespace Poc.DemoNetCore.Domain.Core.Repositories.Base
{
    public interface IPesquisa<T>
    {
        List<T> Search(T entity);
    }
}
