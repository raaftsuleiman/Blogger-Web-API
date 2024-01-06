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
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;

        }

        //Function to Get All Tags 
        [HttpGet]
        [Route("GetAllTags")]
        [ProducesResponseType(typeof(List<Tag>), StatusCodes.Status200OK)]

        public List<Tag> GetAllTags()
        {
            return _tagService.GetAllTags();
        }


        //Function To Create Anew Tag
        [HttpPost]
        [ProducesResponseType(typeof(List<Tag>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateTag(Tag tag)
        {
            return _tagService.CreateTag(tag);
        }


        //Function To Edite Tag Record 
        [HttpPut]
        [ProducesResponseType(typeof(List<Tag>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateTag(Tag tag)
        {
            return _tagService.UpdateTag(tag);
        }

        [Route("DeleteTag/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<Tag>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Delete Tag Record 
        public bool DeleteTag(int id)
        {
            return _tagService.DeleteTag(id);
        }
    }
}
