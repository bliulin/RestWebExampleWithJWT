using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplicationJwtAuth.Models;

namespace WebApplicationJwtAuth.Security
{
    public class JwtManagerRepository : IJwtManagerRepository
    {
        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {
            { "user1","password1"},
            { "user2","password2"},
            { "user3","password3"},
        };

        private readonly IConfiguration config;
        public JwtManagerRepository(IConfiguration configuration)
        {
            this.config = configuration;
        }

        public Token Authenticate(User users)
        {
            if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.Name)
              }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token { TokenValue = tokenHandler.WriteToken(token) };
        }
    }
}
