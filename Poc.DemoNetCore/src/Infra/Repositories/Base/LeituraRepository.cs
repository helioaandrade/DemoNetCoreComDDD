using Poc.DemoNetCore.Domain.Core.Repositories.Base;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Infra.Repositories.Base
{
    public abstract class LeituraRepository<T> : Poc.DemoNetCore.Domain.Core.Repositories.Base.ILeitura<T> where T: Entity
    {
        public DbContext Context { get; }
        public DbSet<T> DbSet => Context.Set<T>();
        public T Get(int id)    
        {

            return Context.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return null;
        }
    }
}
