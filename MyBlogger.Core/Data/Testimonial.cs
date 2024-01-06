using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class Testimonial
    {
        public int Id { get; set; }
        public string FeedBack { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
