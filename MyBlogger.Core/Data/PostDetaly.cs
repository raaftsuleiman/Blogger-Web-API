using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;



namespace MyBlogger.API.Core.Data
{
    public partial class PostDetaly
    {
        public int Id { get; set; }
        public string Descreption { get; set; }
        public int? Postid { get; set; }

        public virtual Post Post { get; set; }
    }
}
