using System;

namespace Infra.Transactions
{
    public interface IUow : IDisposable
    {
        void Commit();
    }
}
