using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class AboutU
    {
       

        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<WebSiteInfo> WebSiteInfos { get; set; }
    }
}
