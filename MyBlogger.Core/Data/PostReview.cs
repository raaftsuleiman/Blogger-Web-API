using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;



namespace MyBlogger.API.Core.Data
{
    public partial class PostReview
    {
        public int Id { get; set; }
        public int? Postid { get; set; }
        public int? Stars { get; set; }

        public virtual Post Post { get; set; }
    }
}
