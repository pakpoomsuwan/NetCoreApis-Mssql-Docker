using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetCoreApis_Mssql_Docker.Models.Auth;
using NetCoreApis_Mssql_Docker.Repositorys;

namespace NetCoreApis_Mssql_Docker.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IAuthRepository _repo;
        public AuthService(IAuthRepository repository, IConfiguration configuration)
        {
            _repo = repository;
            _config = configuration;
        }
        public string Login(Login req)
        {
            string _token = string.Empty;
            _token = BuildToken(req);

            return _token;
        }

        private string BuildToken(Login req)
        {
            // key is case-sensitive
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "For Testing"),
                new Claim("username", req.UserName),
                new Claim(ClaimTypes.Role, req.Password)
            };

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["Jwt:ExpireDay"]));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}