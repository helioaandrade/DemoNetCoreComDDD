using System.Linq;
using Infra;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

using Infra.Transactions;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System;

namespace InfraTest.Entities
{
    public abstract class EntityTestBase<TEntity> where TEntity : Entity, new()
    {

        public DemoContext _db => StartUp.Db;
        public DbSet<TEntity> DbSet => StartUp.Db.Set<TEntity>();
        public virtual TEntity ObjetoMock { get; set; }

        public TEntity ObjetoMockClone() => (TEntity)ObjetoMock.Clone();

        public void Add()
        {
            DbSet.Add(ObjetoMock);
            _db.SaveChanges();
            var entity = DbSet.Find(ObjetoMock.Id);
            entity.NotNull();
        }


        public void Update(System.Func<TEntity, bool> exp)
        {
            _db.Update(ObjetoMock);
            _db.SaveChanges();

            var entity = DbSet.AsNoTracking().FirstOrDefault(exp);
            entity.NotNull();
        }

        public Property Include<Property>(Expression<Func<TEntity, Property>> exp)
        {
            var nameProperty = ((MemberExpression)exp.Body).Member.Name;


            var entity = DbSet.Include(exp).FirstOrDefault(x=>x.Id == ObjetoMock.Id);
            var property = entity.GetType().GetProperties().FirstOrDefault(x => x.Name == nameProperty);
            if (property == null) return (Property)(object)null;
           
            var value = property.GetValue(entity);
            value.NotNull();
            return (Property)value;

        }
        public void Delete()
        {
            DbSet.Remove(ObjetoMock);
            _db.SaveChanges();
            var entity = DbSet.AsNoTracking().FirstOrDefault(x => x.Id == ObjetoMock.Id);

            entity.Null();
        }

        public virtual void All()
        {
            var str = typeof(TEntity).Name;
            var list = DbSet.AsNoTracking().ToList();

            list.NotNull();

        }

    }
}
