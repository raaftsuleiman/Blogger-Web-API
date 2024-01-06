using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public  class DisplayPostComments
    {
        public int Postid { get; set; }

        public string Fname { get; set; }
       public string LastName { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime LastModification { get; set; }
        
    }
}
