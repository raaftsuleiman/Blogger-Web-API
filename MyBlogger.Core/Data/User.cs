using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;



namespace MyBlogger.API.Core.Data
{
    public partial class User
    {
     
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? RegisterdAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string ProfileDescription { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<UserReview> UserReviews { get; set; }
    }
}
