using BE.Application.Interfaces;
using BE.Application.Models;
using BE.Domain.Identity;
using BE.Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infrastructure.Services
{
    public class JwtManager : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtManager(IOptions<JwtSettings> jwtSettingOptions)
        {
            _jwtSettings = jwtSettingOptions.Value;

        }

    

        public Task<JwtDto> GenerateTokenAsync(Guid userId, string email,List<string> roles, CancellationToken cancellationToken)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationInMinute);

            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Email, email),
                 new Claim("uid",userId.ToString()),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iss,_jwtSettings.Issuer),
                 new Claim(JwtRegisteredClaimNames.Aud,_jwtSettings.Audience),
                 new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToFileTimeUtc().ToString()),
                 new Claim(JwtRegisteredClaimNames.Exp,expirationTime.ToFileTimeUtc().ToString()),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                 _jwtSettings.Issuer,
                 _jwtSettings.Audience,
                 claims,
                 expires: expirationTime,
                 signingCredentials: credentials
                 );

            var token=new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(new JwtDto(token, expirationTime));
        }
    }
}
