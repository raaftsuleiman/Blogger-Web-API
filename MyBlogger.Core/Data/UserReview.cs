using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;



namespace MyBlogger.API.Core.Data
{
    public partial class UserReview
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? Stars { get; set; }

        public virtual User User { get; set; }
    }
}
