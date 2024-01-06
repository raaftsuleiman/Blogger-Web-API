using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;



namespace MyBlogger.API.Core.Data
{
    public partial class Tag
    {
      

        public int Id { get; set; }
        public string Title { get; set; }
        public string MetatTitle { get; set; }
        public string Slug { get; set; }
        public string Context { get; set; }
        public byte? IsPublished { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModification { get; set; }
        public DateTime? PublishedOn { get; set; }

        public virtual ICollection<PostTage> PostTages { get; set; }
    }
}
