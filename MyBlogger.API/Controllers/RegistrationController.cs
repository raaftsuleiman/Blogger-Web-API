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
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _RegistreationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _RegistreationService = registrationService;

        }

        [HttpGet]
        public List<Registreation> GetAll()
        {
            return _RegistreationService.GetAll();
        }


        [HttpPost]
        public bool CreateRegistreation([FromBody] Registreation Registreation)
        {
            return _RegistreationService.CreateRegistreation(Registreation);
        }

        [HttpPut]
        public bool UpdateRegistreation(Registreation Registreation)
        {
            return _RegistreationService.UpdateRegistreation(Registreation);
        }


        [HttpDelete, Route("delete/{id}")]
        public bool DeleteRegistreation(int id)
        {
            return _RegistreationService.DeleteRegistreation(id);
        }
    }
}
