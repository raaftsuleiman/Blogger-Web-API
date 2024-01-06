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
    public class PostReviwController : Controller
    {
        private readonly IPostReviewService _postReviewService;
        public PostReviwController(IPostReviewService postReviewService)
        {
            _postReviewService = postReviewService;

        }

        //Function to Get All Reviews 
        [HttpGet]
        [Route("GetAllPostReview")]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]

        public List<PostReview> GetAllReviwes()
        {
            return _postReviewService.GetAllReviwes();
        }


        //Function To Create Anew Reviw
        [HttpPost]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateReview(PostReview postReview)

        {
            return _postReviewService.CreateReview(postReview);
        }


        //Function To Edite Review Record 
        [HttpPut]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateReview(PostReview postReview)
        {
            return _postReviewService.UpdateReview(postReview);
        }

        [Route("DeleteComment/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<PostReview>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Delete review Record 
        public bool DeleteReview(int id)
        {
            return _postReviewService.DeleteReview(id);
        }
    }
}
