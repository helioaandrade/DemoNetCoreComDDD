using Infra.Utils.AppSettings;
 
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Util
{
    public class Authorization
    {
        private readonly TokenConfiguration _tokenConfiguration;
        private string _senha { get; set; }
        private string _login { get; set; }
        public Authorization(TokenConfiguration configuration, string login, string senha)
        {
            _tokenConfiguration = configuration;
            _senha = senha;
            _login = login;
        }
        public JwtSecurityToken GenerateToken()
        {
            var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, _senha),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim("usuario", _login)
        };
            return new JwtSecurityToken
                (
                    issuer: _tokenConfiguration.Issuer,
                    audience: _tokenConfiguration.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    notBefore: DateTime.Now,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.IssuerSigningKey)),
                            SecurityAlgorithms.HmacSha256)
                );
        }
    }
}
