using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Restaurante.Domain.Response;

namespace Restaurante.Service.Common
{
    public class JWT
    {
        public static List<string> Roles;

        public static LoginResponse BuildToken(string usuario, long expireMinutes, string issuer, string secretKey, string nome)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiry = DateTime.UtcNow.AddMinutes(expireMinutes);

            var claims = GetTokenClaims(usuario, nome);

            var token = new JwtSecurityToken(
              issuer,
              issuer,
              claims,
              expires: expiry,
              signingCredentials: creds
             );

            var result = new LoginResponse()
            {
                Authenticated = true,
                Created = DateTime.Now,
                ExpiresIn = expireMinutes * 60,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Roles = Roles
            };

            return result;
        }

        private static IEnumerable<Claim> GetTokenClaims(string user, string nome)
        {
            var clains = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, nome),
                new Claim(JwtRegisteredClaimNames.UniqueName, user)
        };
            
            return clains;
        }
    }
}
