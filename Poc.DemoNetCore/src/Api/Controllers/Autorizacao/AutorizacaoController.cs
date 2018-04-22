using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Base;
using Infra.Transactions;
using Microsoft.AspNetCore.Cors;
using Api.Models;
using Infra.Utils.AppSettings;
using System.IdentityModel.Tokens.Jwt;
using Api.Util;

namespace Api.Controllers.Autorizacao
{

    public class AutorizacaoController : Controller
    {
        private TokenConfiguration _tokenConfiguration;


        [EnableCors("Cors")]
        [HttpGet]
        [Route("api/Autorizacao/Token")]
        public IActionResult Token(string Login, string Senha)
        {
            try
            {

                // TODO: Deve criar tabela de usuário para validar login/senha
                //  [FromBody]LoginRequest req
                //if (req.Login != "admin" && req.Senha != "admin")
                if (Login != "admin" && Senha != "admin")
                {
                    return Unauthorized();
                }

                _tokenConfiguration = new TokenConfiguration
                {
                    Audience = "API",
                    Issuer = "API",
                    IssuerSigningKey = "7f7ec698-d341-4e19-b6e1-9c70fd3f5df6"
                };

                var authorization = new Authorization(_tokenConfiguration, Login, Senha);
                var token = authorization.GenerateToken();

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }
            catch (Exception ex)
            {
                BadRequest(new { message = ex.Message });
            }

            return BadRequest();
        }
    }
}