using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infra.Transactions
{
    public sealed class Uow : IUow
    {
       public DemoContext _db;
          
       // public Contexto _db;
        public IDbConnection _connection;
        public IDbTransaction _transaction;
        private bool _disposed;

        public Uow(IOptions<AppSettings> appSettings, DemoContext context)
        {
            _db = context;
            _connection = _db.Database.GetDbConnection();
        }

        public void Commit()
        {
        }

        public void Dispose()
        {
            
        }
    }
}
