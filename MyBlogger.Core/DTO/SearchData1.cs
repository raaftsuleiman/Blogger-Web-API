using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public  class SearchData1
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lastname { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }

        public string Title { get; set; }
        public string PostContant { get; set; }
        public DateTime CreateAt { get; set; }
        public string CategoryTitle { get; set; }

        public string metaTitle { get; set; }
    }
}
