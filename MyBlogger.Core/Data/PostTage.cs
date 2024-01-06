using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class PostTage
    {
        public int Id { get; set; }
        public int? Postid { get; set; }
        public int? TageId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tage { get; set; }
    }
}
