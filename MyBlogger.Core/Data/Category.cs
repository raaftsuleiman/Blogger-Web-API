using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class Category
    {
       

        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime? LastModification { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
