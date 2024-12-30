using ReposSearchAppServer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ReposSearchAppServer.Services
{
    public class AuthService : BaseService, IAuthInterface
    {
        public readonly IConfiguration _configuration;
        public AuthService(
           AppContext ctx,
           ILogger<SearchService> logger,
           IConfiguration configure) : base(ctx, logger)
        {
            _configuration = configure;
        }

        public string GenerateJwtToken()
        {
            //Generate the JWT token when user access to project
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
