using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {

            _loginService=loginService;
        }
        // Create  

        [HttpPost]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreateLogin(Login login)
        {

            return _loginService.CreateLogin(login);

        }

        // Update

        [HttpPut]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateLogin([FromBody] Login login)
        {
            return _loginService.UpdateLogin(login);
        }



        [HttpPut]
        [Route("ResetPassword")]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool RestPassword( Login login)
        {
            return _loginService.RestPassword(login);
        }

        // Delete

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteLogin(int id)
        {
            return _loginService.DeleteLogin(id);
        }


        // Get All

        [HttpGet]
        [Route("GetAllLogin")]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Login> GetAllLogin()
        {
            return _loginService.GetAllLogin();
        }

        //Get By Id

        [HttpGet]
        [Route("GetLoginBy/{Id}")]
        [ProducesResponseType(typeof(List<Login>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Login> GetLoginDetailsById(int id)
        {
            return _loginService.GetLoginDetailsById(id);
        }

    }
}
