using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSiteInfoController : Controller
    {
        private readonly IWebSiteInfoService _webSiteInfoService;
        public WebSiteInfoController(IWebSiteInfoService webSiteInfoService)
        {
            _webSiteInfoService = webSiteInfoService;
        }
        // Create  

        [HttpPost]
        [ProducesResponseType(typeof(List<WebSiteInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreateWebSiteinfo(WebSiteInfo webSiteInfo)
        {

            return _webSiteInfoService.CreateWebSiteinfo(webSiteInfo);

        }

        // Update

        [HttpPut]
        [ProducesResponseType(typeof(List<WebSiteInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateWebSiteInfo([FromBody] WebSiteInfo webSiteInfo)
        {
            return _webSiteInfoService.UpdateWebSiteInfo(webSiteInfo);
        }


        // Delete

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(List<WebSiteInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeleteWebSiteInfo(int id)
        {
            return _webSiteInfoService.DeleteWebSiteInfo(id);
        }

        // Get All

        [HttpGet]
        [Route("GetAllWebSite")]
        [ProducesResponseType(typeof(List<WebSiteInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<WebSiteInfo> GetAllWebSiteInfo()
        {
            return _webSiteInfoService.GetAllWebSiteInfo();
        }
    }
}
