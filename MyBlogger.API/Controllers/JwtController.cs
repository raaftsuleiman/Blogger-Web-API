using Microsoft.AspNetCore.Http;
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
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogger.Core.Repository
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtservice jwtservice;
        public JwtController(IJwtservice jwtservice)
            {
            this.jwtservice = jwtservice;
        }

        [HttpPost]
        public IActionResult Authen([FromBody]Login login)
        {
            var token = jwtservice.Auth(login);
            if (token==null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }

        }
    }
}
