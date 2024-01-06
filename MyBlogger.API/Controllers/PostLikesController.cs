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
    public class PostLikesController : Controller
    {
        private readonly IPostLikesService _postLikesService;
        public PostLikesController(IPostLikesService postLikesService)
        {
            _postLikesService = postLikesService;
           
        }
        [HttpGet]
        [Route("CountOfLikes")]
        //Function to Get Count Of All Likes
        public int CountOfLikes()
        {
            return _postLikesService.CountOfLikes();
        }

        //Function to Get All Likes 
        [HttpGet]
        [Route("GetAllPostLike")]
        [ProducesResponseType(typeof(List<PostLike>), StatusCodes.Status200OK)]

        public List<PostLike> GetAllPostLike()
        {
            return _postLikesService.GetAllPostLike();
        }


        //Function To Create Anew Likes
        [HttpPost]
        [ProducesResponseType(typeof(List<PostLike>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateLike(PostLike postLike)
        {
            return _postLikesService.CreateLike(postLike);
        }


        //Function To Edite Like Record 
        [HttpPut]
        [ProducesResponseType(typeof(List<PostLike>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateLike(PostLike postLike)
        {
            return _postLikesService.UpdateLike(postLike);
        }

        [Route("DeleteLike/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<PostLike>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Delete Like Record 
        public bool DeleteLike(int id)
        {
            return _postLikesService.DeletePostLike(id);
        }

        //Function To Get Count Of Likes On Posts

        [HttpGet]
        [Route("LikesOnPost/{Id}")]
        [ProducesResponseType(typeof(List<PostLike>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int CountOfPostLikes(int id)
        {
            return _postLikesService.CountOfPostLikes(id);
        }
    }
}
