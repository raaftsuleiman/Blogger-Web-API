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
    public class TestimonealController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonealController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Testimonial> GetAll()
        {
            return _testimonialService.GetAll();
        }

        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetTestimonialbyId/{id}")]
        public List<Testimonial> GetTestimonialbyId(int id)
        {
            return _testimonialService.GetTestimonialbyId(id);
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateTestimonial([FromBody] Testimonial Testimonial)
        {
            return _testimonialService.CreateTestimonial(Testimonial);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateTestimonial(Testimonial Testimonial)
        {
            return _testimonialService.UpdateTestimonial(Testimonial);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(List<ContactU>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteTestimonial(int id)
        {
            return _testimonialService.DeleteTestimonial(id);
        }
    }
}
