using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public  class GitMaxAndMinRatinByPostTitleORId
    {
        public string PostTitle { get; set; }
        public string Bloger { get; set; }
        public int MaxRating { get; set; }
        public int MinRating { get; set; }
    }
}
