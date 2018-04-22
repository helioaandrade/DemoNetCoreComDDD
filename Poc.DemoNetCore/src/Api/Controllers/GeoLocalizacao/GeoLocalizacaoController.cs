using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poc.DemoNetCore.Domain.Core.Repositories.GeoLocalizacao;
using Api.Controllers.Base;
using Infra.Transactions;
using Microsoft.AspNetCore.Cors;
using Poc.DemoNetCore.Domain.Core.Commands.Handlers.GeoLocalizacao;
using Poc.DemoNetCore.Domain.Core.Commands.Inputs.GeoLocalizacao;
using Api.Models;
using Infra.Utils.AppSettings;
using Api.Util;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.GeoLocalizacao
{
    public class GeoLocalizacaoController : BaseController
    {

        // private readonly TokenConfiguration _tokenConfiguration;

        #region Handlers
        private readonly IncluirPessoaCommandHandler _pessoaCommandHandler;
        private readonly IncluirCalculoHistoricoLogCommandHandler _calculoHistoricoCommandHandler;
        #endregion

        #region Repositórios
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICalculoHistoricoLogRepository _calculoHistoricoLogRepository;
        #endregion

        public GeoLocalizacaoController(
             Uow uow_
             , IncluirPessoaCommandHandler pessoaCommandHandler_
             , IncluirCalculoHistoricoLogCommandHandler calculoHistoricoCommandHandler_
             , IPessoaRepository pessoaRepository_
             , ICalculoHistoricoLogRepository calculoHistoricoLogRepository_
             ) : base(uow_)
        {
            _pessoaCommandHandler = pessoaCommandHandler_;
            _calculoHistoricoCommandHandler = calculoHistoricoCommandHandler_;
            _pessoaRepository = pessoaRepository_;
            _calculoHistoricoLogRepository = calculoHistoricoLogRepository_;
        }


        [EnableCors("Cors")]
        [HttpGet]
        [Route("api/GeoLocalizacao/ListarPessoas")]
        //[Authorize]
        public async Task<IActionResult> ListarAmigos()
        {
            try
            {
                String token = this.Request.Headers["Authorization"];

                var result = _pessoaRepository.List();
                return await Response(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }

        [EnableCors("Cors")]
        [HttpGet]
        [Route("api/GeoLocalizacao/AmigosMaisProximos/Listar/{Nome}")]
        //[Authorize]
        public async Task<IActionResult> ListarAmigosMaisProximos(string Nome)
        {
            try
            {
                var result = _pessoaRepository.ObterAmigosMaisProximo(Nome);
                return await Response(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }


        [EnableCors("Cors")]
        [HttpPost]
        [Route("api/GeoLocalizacao/Pessoa/Incluir")]

        public async Task<IActionResult> IncluirPessoa([FromBody] PessoaInputCommand command)
        {
            try
            {
                var commandReturn = _pessoaCommandHandler.Handle(command);

                return await Response(commandReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }

        [EnableCors("Cors")]
        [HttpGet]
        [Route("api/GeoLocalizacao/HistoricosLog/Listar")]
        public async Task<IActionResult> ListarHistoricosLog()
        {
            try
            {
                var result = _calculoHistoricoLogRepository.List();
                return await Response(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }

        [EnableCors("Cors")]
        [HttpPut]
        [Route("api/GeoLocalizacao/CalculoLog/Incluir")]
        public async Task<IActionResult> IncluirCalculoHistoricoLog([FromBody]CalculoHistoricoLogInputCommand command)
        {
            try
            {
                var commandReturn = _calculoHistoricoCommandHandler.Handle(command);

                return await Response("");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }


    }
}
