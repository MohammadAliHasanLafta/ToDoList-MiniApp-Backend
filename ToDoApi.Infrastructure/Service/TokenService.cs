using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Infrastructure.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(MiniAppUser miniAppUser, WebAppUser webAppUser)
        {
            var authClaims = new List<Claim>();
            if (miniAppUser != null)
            {
                authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, miniAppUser.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, miniAppUser.LastName),
                };
            }

            else
            {
                authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, webAppUser.PhoneNumber),
                    new Claim(ClaimTypes.MobilePhone, webAppUser.PhoneNumber),
                };
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
