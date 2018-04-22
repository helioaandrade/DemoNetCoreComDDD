 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;
using System;
using System.Linq;
using System.Reflection;

namespace Infra
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }


        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<CalculoHistoricoLog> CalculosHistoricosLogs { get; set; }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly
                .GetTypes()
                .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .Where(x => x.Name.Contains("ProfileMap")).ToArray();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var configurations = GetTypesInNamespace(this.GetType().Assembly, "Infra.EntityConfiguration").Select(Activator.CreateInstance);

            configurations.ToList().ForEach(x =>
            {
                MethodInfo method = x.GetType().GetMethod("Config");
                method.Invoke(x, new object[] { modelBuilder });
            });

            NormalizeTable(modelBuilder);


        }

        public static void NormalizeTable(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.ClrType.GetProperties();
                var entityName = entity.DisplayName();
                entity.Relational().TableName = entityName;

                if (properties.Any(x => x.Name == $"{entityName}ID"))
                    modelBuilder.Entity(entity.ClrType).Ignore($"{entityName}ID");

                if (properties.Any(x => x.Name == "IsValid"))
                    modelBuilder.Entity(entity.ClrType).Ignore($"IsValid");


                if (properties.Any(x => x.Name == "Id"))
                {
                    modelBuilder.Entity(entity.ClrType).HasKey($"Id");
                }
            }
        }
    }
}