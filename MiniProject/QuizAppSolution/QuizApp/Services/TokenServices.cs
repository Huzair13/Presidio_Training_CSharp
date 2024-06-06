﻿using Microsoft.IdentityModel.Tokens;
using QuizApp.Interfaces;
using QuizApp.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizApp.Services
{
    public class TokenServices : ITokenServices
    {
        //INITIALIZATION
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        //DEPENDENCY INJECTION
        public TokenServices(IConfiguration configuration)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }

        //GENERATE TOKEN
        public async Task<string> GenerateToken(User user)
        {
            string role = await GetRole(user);
            return await GetToken(user, role);
        }

        //GET TOKEN
        private async Task<string> GetToken(User user, string role)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role ,role)
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }

        //GET ROLE
        private async Task<string> GetRole(User user)
        {
            if (user is Teacher)
            {
                return "Teacher";
            }
            else if (user is Student)
            {
                return "Student";
            }
            return null;
        }
    }
}
