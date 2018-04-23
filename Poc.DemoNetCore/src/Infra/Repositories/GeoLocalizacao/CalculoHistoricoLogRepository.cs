using Infra.Transactions;
using Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao;
using System;
using System.Collections.Generic;
using System.Text;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;
using System.Linq;

namespace Infra.Repositories.GeoLocalizacao
{
    public class CalculoHistoricoLogRepository : ICalculoHistoricoLogRepository
    {
        private Uow _uow;

        public CalculoHistoricoLogRepository(Uow uow_)
        {
            _uow = uow_;
        }

        public void Delete(CalculoHistoricoLog entity)
        {
            _uow._db.Remove(entity);
            _uow._db.SaveChanges();
        }

        public CalculoHistoricoLog Get(int id)
        {
            return _uow._db.CalculosHistoricosLogs.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<CalculoHistoricoLog> List()
        {
            return _uow._db.CalculosHistoricosLogs.ToList();
        }

        public CalculoHistoricoLog Save(CalculoHistoricoLog entity)
        {
            try
            {
                entity.UltimaAtualizacao = System.DateTime.Now;
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

        public List<CalculoHistoricoLog> Search(CalculoHistoricoLog entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CalculoHistoricoLog entity)
        {
            _uow._db.Update(entity);
            _uow._db.SaveChanges();
        }
    }
}
