using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public  interface IWebSiteInfoRepository
    {

        public bool CreateWebSiteinfo(WebSiteInfo webSiteInfo);

        public bool DeleteWebSiteInfo(int id);

        public bool UpdateWebSiteInfo(WebSiteInfo webSiteInfo);

        public List<WebSiteInfo> GetAllWebSiteInfo();
    }
}
