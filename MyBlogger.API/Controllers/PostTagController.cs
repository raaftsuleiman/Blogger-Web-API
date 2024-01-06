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
    public class PostTagController : ControllerBase
    {
        private readonly IPostTagService _PostTageService;
        public PostTagController(IPostTagService postTagService)
        {
            _PostTageService = postTagService;

        }

        [HttpGet]
        public List<PostTage> GetAll()
        {
            return _PostTageService.GetAll();
        }


        [HttpPost]
        public bool CreatePostTage([FromBody] PostTage PostTage)
        {
            return _PostTageService.CreatePostTage(PostTage);
        }

        [HttpPut]
        public bool UpdatePostTage(PostTage PostTage)
        {
            return _PostTageService.UpdatePostTage(PostTage);
        }


        [HttpDelete, Route("delete/{id}")]
        public bool DeletePostTage(int id)
        {
            return _PostTageService.DeletePostTage(id);
        }
    }
}
