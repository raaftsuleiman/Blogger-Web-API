using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository)
        {

            _testimonialRepository = testimonialRepository;
        }
     

            public List<Testimonial> GetAll()
            {
                return _testimonialRepository.GetAll();
            }


            public bool CreateTestimonial(Testimonial testimonial)
            {
                return _testimonialRepository.CreateTestimonial(testimonial);
            }
            public bool UpdateTestimonial(Testimonial testimonial)
            {
                return _testimonialRepository.UpdateTestimonial(testimonial);
            }

            public bool DeleteTestimonial(int id)
            {
                return _testimonialRepository.DeleteTestimonial(id);
            }
        public List<Testimonial> GetTestimonialbyId(int id)
        {
            return _testimonialRepository.GetTestimonialbyId(id);
        }


    }
}
