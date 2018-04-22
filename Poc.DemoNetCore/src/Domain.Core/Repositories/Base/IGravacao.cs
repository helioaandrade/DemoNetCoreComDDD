namespace Poc.DemoNetCore.Domain.Core.Repositories.Base
{
    public interface IGravacao<T>
    {
        T Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
