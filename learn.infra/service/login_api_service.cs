using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using Microsoft.IdentityModel.Tokens;

namespace learn.infra.service
{
    public class login_api_service : Ilogin_api_service
    {
        private readonly Ilogin_api_repoisitory repo;
        public login_api_service(Ilogin_api_repoisitory repo)
        {
            this.repo = repo;
        }

        public string auth(login_api login)
        {
          var result= repo.auth(login);
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Email,result.username),
                    new Claim(ClaimTypes.Role, result.role),
                    new Claim(ClaimTypes.Name, result.id.ToString())

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }
    }
}
