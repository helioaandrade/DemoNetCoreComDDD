using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration
{
    public class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Config(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}
