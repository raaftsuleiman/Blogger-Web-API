using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;




namespace MyBlogger.API.Core.Data
{
    public partial class WebSiteInfo
    {
        public int Id { get; set; }
        public int? Aboutid { get; set; }
        public int? ContactId { get; set; }
        public int? PostId { get; set; }

        public virtual AboutU About { get; set; }
        public virtual ContactU Contact { get; set; }
        public virtual Post Post { get; set; }
    }
}
