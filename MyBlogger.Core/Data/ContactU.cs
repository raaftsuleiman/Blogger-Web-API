using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class ContactU
    {
      

        public int Id { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string ContactMobile { get; set; }

        public virtual ICollection<WebSiteInfo> WebSiteInfos { get; set; }
    }
}
