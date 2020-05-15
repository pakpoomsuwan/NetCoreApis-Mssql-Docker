using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NetCoreApis_Mssql_Docker.Models.Auth;
using NetCoreApis_Mssql_Docker.Repositorys;

namespace NetCoreApis_Mssql_Docker.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        public AuthService(IAuthRepository repository)
        {
            _repo = repository;
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

            var expires = DateTime.Now.AddDays(Convert.ToDouble("30"));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Pakp00m.NetCore777"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Pakpoom Suwan",
                audience: "http://codemobiles.com",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}