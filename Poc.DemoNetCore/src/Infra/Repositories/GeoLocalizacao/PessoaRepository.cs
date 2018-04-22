using Infra.Transactions;
using Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao;
using System;
using System.Collections.Generic;
using System.Text;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;
using System.Linq;

namespace Infra.Repositories.GeoLocalizacao
{
    public class PessoaRepository : IPessoaRepository
    {
         private Uow _uow;

        public PessoaRepository(Uow uow_)
        {
            _uow = uow_;
        }

        public void Delete(Pessoa entity)
        {
            _uow._db.Remove(entity);
            _uow._db.SaveChanges();
        }

        public Pessoa Get(int id)
        {
            return _uow._db.Pessoas.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Pessoa> List()
        {
            return _uow._db.Pessoas.ToList();
        }

        public Pessoa Save(Pessoa entity)
        {
            try
            {
                _uow._db.Add(entity);
                _uow._db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
          
        }

        public List<Pessoa> Search(Pessoa entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pessoa entity)
        {
            _uow._db.Update(entity);
            _uow._db.SaveChanges();
        }
    }
}
