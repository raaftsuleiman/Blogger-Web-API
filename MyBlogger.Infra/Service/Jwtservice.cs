using Microsoft.IdentityModel.Tokens;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.DTO;
using MyBlogger.Core.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyBlogger.Core.Repository
{
    public class Jwtservice : IJwtservice
    {
        private readonly IJwtRepositorycs reposiytory;
        public Jwtservice(IJwtRepositorycs reposiytory)
        {
            this.reposiytory = reposiytory;
        }

        public string Auth(Login login)
        {

            var result = reposiytory.auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                      new Claim(ClaimTypes.Name, result.Username),
                      new Claim(ClaimTypes.Role,result.RoleName ),
                      new Claim(CustomClaim.UserId, Convert.ToString(result.Userid)),



                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }



        }
    }
    public static class CustomClaim
    {
        public const string UserName = "UserName";
        public const string Email = "Email";
        public const string RoleId = "RoleId";
        public const string RoleName = "RoleName";
        public const string IdentityNumber = "IdentityNumber";
        public const string UserId = "UserId";
        public const string TableId = "TableId";
    }



}