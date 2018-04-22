using System;
using System.Collections.Generic;
using System.Text;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration
{
    public class RelationMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {

        public Type Type => typeof(TEntity);
        public string Name => Type.Name;
        public void Config(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            

        }
    }
}
