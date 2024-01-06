using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
  public  interface ITestimonialRepository
    {
        public List<Testimonial> GetAll();
        public bool CreateTestimonial(Testimonial testimonial);
        public bool UpdateTestimonial(Testimonial testimonial);
        public bool DeleteTestimonial(int id);
        public List<Testimonial> GetTestimonialbyId(int id);
    }
}
