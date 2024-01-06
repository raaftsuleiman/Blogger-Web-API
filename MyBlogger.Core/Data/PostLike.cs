using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{ 
    public partial class PostLike
    {
        public int Id { get; set; }
        public byte? IsLiked { get; set; }
        public int? Postid { get; set; }
        public int? Userid { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
