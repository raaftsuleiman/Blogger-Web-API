using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public class PostWithGoodReview
    {
        public int  Id { get; set; }

        public string PostTitle { get; set; }
        public string Bloger { get; set; }
        public int Rate { get; set; }

    }
}
