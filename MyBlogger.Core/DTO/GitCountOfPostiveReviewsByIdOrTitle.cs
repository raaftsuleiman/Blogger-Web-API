using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public  class GitCountOfPostiveReviewsByIdOrTitle
    {
        public int CountOfPostiveReviwes { get; set; }

        public string PostTitle { get; set; }
        public string Bloger { get; set; }
    }
}
