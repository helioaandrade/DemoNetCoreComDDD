using Infra.Transactions;
using Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao;
using System;
using System.Collections.Generic;
using System.Text;
using Poc.DemoNetCore.Domain.Core.Entities.GeoLocalizacao;
using System.Linq;
using Poc.DemoNetCore.Domain.Shared.Utils.Helpers;
using Infra.Utils.Helpers;
using Poc.DemoNetCore.Domain.Core.Dto;

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

        public List<Tracking> ObterAmigosMaisProximo(string Nome)
        {
            List<Tracking> tracking = new List<Tracking>();

            try
            {
                var pessoas = _uow._db.Pessoas.Where(x => x.Nome.Trim().ToLower() == Nome.Trim().ToLower());

                if (pessoas == null || pessoas.Count() == 0)
                    return tracking;

                var pessoaOrigem = pessoas.ToList().FirstOrDefault();

                var outrasPessoas = _uow._db.Pessoas.Where(x => x.Id != pessoaOrigem.Id).ToList();

                foreach (var pessoa in outrasPessoas)
                {
                    var localizacaoOrigem = new Localizacao()
                    {
                        Latitude = Convert.ToDouble(pessoaOrigem.Latitude),
                        Longitude = Convert.ToDouble(pessoaOrigem.Longitude)
                    };

                    var localizacaoDestino = new Localizacao()
                    {
                        Latitude = Convert.ToDouble(pessoa.Longitude),
                        Longitude = Convert.ToDouble(pessoa.Longitude)
                    };

                    double distancia = TrackingHelper.CalculateDistance(localizacaoOrigem, localizacaoDestino);

                    tracking.Add(new Tracking
                    {
                        PessoaId = pessoa.Id,
                        Nome = pessoa.Nome,
                        Distancia = Math.Round(distancia, 2)
                    });

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tracking.OrderBy(x => x.Distancia).Take(3).ToList();
        }
    }
}
