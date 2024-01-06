using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public class GetLastesPost
    {
        public string Title { get; set; }
        public string metaTitle { get; set; }
        public string Image { get; set; }
        public string CreateAt { get; set; }

    }
}
