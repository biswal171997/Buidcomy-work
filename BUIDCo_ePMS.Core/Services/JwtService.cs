using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Core.Services
{
    public class JwtService:IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        public string GenerateToken(string username,string roleId,string userId,string leveldetailsId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"].ToString());

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, roleId), // Example role;
            new Claim("UserId", userId),
            new Claim("Intleveldetailsid", leveldetailsId)

                }),
                    Expires = DateTime.UtcNow.AddHours(Convert.ToDouble( _configuration["Jwt:TokenValidityInHours"])),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
