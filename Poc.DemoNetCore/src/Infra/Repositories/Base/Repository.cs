using System.Data;

namespace Infra.Repositories
{
    public abstract class Repository
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }

        public Repository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }
}
