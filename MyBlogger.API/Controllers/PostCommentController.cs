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
    public class PostCommentController : Controller
    {
        private readonly IPostCommentServise _postCommentServise;
        public PostCommentController(IPostCommentServise postCommentServise)
        {

            _postCommentServise = postCommentServise;
        }

        [HttpGet]
        [Route("CountOfComments")]
        //Function to Get Count Of All Comments 
        public int CountOfComments()
        {
            return _postCommentServise.CountOfComments();
        }

        //Function to Get All Comment 
        [HttpGet]
        [Route("GetAllPostComment")]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]

        public List<PostComment> GetAllComments()
        {
            return _postCommentServise.GetAllComments();
        }


        //Function To Create Anew Comment
        [HttpPost]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateComment(PostComment postComment)
        {
            return _postCommentServise.CreateComment(postComment);
        }


        //Function To Edite comment Record 
        [HttpPut]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateComment(PostComment postComment)
        {
            return _postCommentServise.UpdateComment(postComment);
        }

        [Route("DeleteComment/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Delete comment Record 
        public bool DeleteComment(int id)
        {
            return _postCommentServise.DeleteComment(id);
        }

        //Function To Update User's Comments
        [HttpPut]
        [Route("UpdateUserComment")]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UserUpdateHisComment(PostComment postComment)
        {
            return _postCommentServise.UserUpdateHisComment(postComment);
        }

        //Function To Get Count Of Comment On Posts
        [HttpGet]
        [Route("CommentOnPost/{Id}")]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int CountOfPostComment(int id)
        {
            return _postCommentServise.CountOfPostComment(id);
        }

        [HttpGet]
        [Route("GetCommentByUserIdAndPostId/{userid}/{postid}")]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]

        public List<PostComment> GetCommentByUserIdAndPostId(int userid, int postid)
        {
            return _postCommentServise.GetCommentByUserIdAndPostId(userid, postid);
        }


        [Route("DeleteUserComment/{CommentId}/{UserId}/{PostId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<PostComment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Function To Delete comment Record 
        public bool UserDeleteHisComment(int UserId, int PostId)

        {
            return _postCommentServise.UserDeleteHisComment( UserId, PostId);
        }



    }
}
