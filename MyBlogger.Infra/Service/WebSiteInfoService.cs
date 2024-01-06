using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public class WebSiteInfoService : IWebSiteInfoService
    {
        private readonly IWebSiteInfoRepository _webSiteInfoRepository;
        public WebSiteInfoService(IWebSiteInfoRepository webSiteInfoRepository)
        {

            _webSiteInfoRepository=webSiteInfoRepository;
        }
        public bool CreateWebSiteinfo(WebSiteInfo webSiteInfo)
        {
            return _webSiteInfoRepository.CreateWebSiteinfo(webSiteInfo);
        }

        public bool DeleteWebSiteInfo(int id)
        {
            return _webSiteInfoRepository.DeleteWebSiteInfo(id);
        }

        public List<WebSiteInfo> GetAllWebSiteInfo()
        {
            return _webSiteInfoRepository.GetAllWebSiteInfo();
        }

        public bool UpdateWebSiteInfo(WebSiteInfo webSiteInfo)
        {
            return _webSiteInfoRepository.UpdateWebSiteInfo(webSiteInfo);
        }
    }
}
