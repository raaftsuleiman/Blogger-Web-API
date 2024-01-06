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
    public class PostDetaliesController : Controller
    {
        private readonly IPostDetaliesService _postDetaliesService;
        public PostDetaliesController(IPostDetaliesService postDetaliesService)
        {

            _postDetaliesService = postDetaliesService;
        }


        //Function to Get All Reviews 
        [HttpGet]
        [Route("GetAllPostDetalies")]
        [ProducesResponseType(typeof(List<PostDetaly>), StatusCodes.Status200OK)]

        public List<PostDetaly> GetAllDetalies()
        {
            return _postDetaliesService.GetAllDetalies();
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Create Anew Detalies
        public bool CreateDetalies(PostDetaly postDetaly)
        {
            return _postDetaliesService.CreateDetalies(postDetaly);
        }


        [HttpPut]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateDetalies(PostDetaly postDetaly)
        //Function To Delete Detalies Record 
        {
            return _postDetaliesService.UpdateDetalies(postDetaly);
        }

        [Route("DeleteComment/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Delete Like Record 
        public bool DeletePostLike(int id)
        {
            return _postDetaliesService.DeleteDetalies(id);
        }
    }
}
