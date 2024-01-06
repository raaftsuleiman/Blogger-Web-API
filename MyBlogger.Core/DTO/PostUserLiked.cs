using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
    public class PostUserLiked
    {
        public string Fname { get; set; }

        public string Lastname { get; set; }

        public string Image { get; set; }

        public string Images { get; set; }

        public string Title { get; set; }

        public string PostContant { get; set; }

        public DateTime? CreateAt { get; set; }

        public string Slug { get; set; }

        public string metaTitle { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }
    }
}
