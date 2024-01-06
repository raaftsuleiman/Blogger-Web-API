using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public byte? IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
        public DateTime? LastModification { get; set; }
        public int? Postid { get; set; }
        public int? Userid { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
