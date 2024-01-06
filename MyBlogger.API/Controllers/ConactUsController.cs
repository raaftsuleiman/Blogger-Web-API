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
    public class ConactUsController : Controller
    {
        private readonly IConactUsService _conactUsService;
        public ConactUsController(IConactUsService conactUsService)
        {

            _conactUsService = conactUsService;
        }

        //Create 
        [HttpPost]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateContactUs(ContactU contactUs)
        {

            return _conactUsService.CreateContactUs(contactUs);

        }

        // Update

        [HttpPut]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateContactUs([FromBody] ContactU contactUs)
        {
            return _conactUsService.UpdateContactUs(contactUs);
        }

        // Delete

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteContactUs(int id)
        {
            return _conactUsService.DeleteContactUs(id);
        }


        // Get All

        [HttpGet]
        [Route("GetAllContactUs")]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        public List<ContactU> GetAllContactUs()
        {
            return _conactUsService.GetAllContactUs();
        }

        //Get By Id

        [HttpGet]
        [Route("GetContactUsById/{Id}")]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        public List<ContactU> GetDetailsContactUsById(int id)
        {
            return _conactUsService.GetDetailsContactUsById(id);
        }

   
       
    }
}
