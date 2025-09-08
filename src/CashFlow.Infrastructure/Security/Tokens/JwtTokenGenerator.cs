﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Sercurity.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Infrastructure.Security.Tokens
{
    public class JwtTokenGenerator : IAccessTokenGenerator
    {
        private readonly uint _expirationTimesMinutes;
        private readonly string _signingKey;

        public JwtTokenGenerator(uint expirationTimesMinutes, string signingKey)
        {
            _expirationTimesMinutes = expirationTimesMinutes;
            _signingKey = signingKey;
        }

        public string GenerateToken(Users user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimesMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }


        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signingKey);
            return new SymmetricSecurityKey(key);
        }
    }
}
