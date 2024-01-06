using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogger.Core.DTO;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTOController : ControllerBase
    {

        private readonly IDTOService _dTOService;
        public DTOController(IDTOService dTOService)
        {

            _dTOService = dTOService;

        }
        //Get Recent  5 Comment with User name and his image

        [HttpGet]
        [Route("GetRecentComment")]
        [ProducesResponseType(typeof(List<GetRecentComment>), StatusCodes.Status200OK)]

        public List<GetRecentComment> GetRecentComments()
        {
            return _dTOService.GetRecentComments();
        }
        //Find the titles of all posts that have Excellent ratings.(stares= 5 or 4

        [HttpGet]
        [Route("PostWithGoodReview")]
        [ProducesResponseType(typeof(List<PostWithGoodReview>), StatusCodes.Status200OK)]

        public List<PostWithGoodReview> PostWithGoodReview()
        {
            return _dTOService.PostWithGoodReview();
        }

        //Find the titles of all posts that have no ratings.(stares= null)*/ 
        [HttpGet]
        [Route("PostWithNullReview")]
        [ProducesResponseType(typeof(List<PostWithNullReview>), StatusCodes.Status200OK)]
        public List<PostWithNullReview> PostWithNullReview()
        {
            return _dTOService.PostWithNullReview();
        }

        //Git The Maximum Rating  And Minimum Rating For Post By its Id or Title 
        [HttpGet]
        [Route("GitMaxAndMinRatinByPostTitleORId/{search}")]
        [ProducesResponseType(typeof(List<GitMaxAndMinRatinByPostTitleORId>), StatusCodes.Status200OK)]
        public List<GitMaxAndMinRatinByPostTitleORId> GitMaxAndMinRatinByPostTitleORId(string search)
        {
            return _dTOService.GitMaxAndMinRatinByPostTitleORId(search );
        }

        //Search posts by User name or by category title or by post title
        [HttpGet]
        [Route("Search/{search}")]
        [ProducesResponseType(typeof(List<SearchData1>), StatusCodes.Status200OK)]

        public List<SearchData1> Search(string search)
        {
            return _dTOService.Search(search);
        }

        //Git The Count of Positive Rating (4-5) Post By its Id or Title 
        [HttpGet]
        [Route("GitCountOfPostiveReviewsByIdOrTitle/{search}")]
        [ProducesResponseType(typeof(List<SearchData1>), StatusCodes.Status200OK)]

        public List<GitCountOfPostiveReviewsByIdOrTitle> GitCountOfPostiveReviewsByIdOrTitle(string search)
        {
            return _dTOService.GitCountOfPostiveReviewsByIdOrTitle(search);
        }

        //procedure to get the  post has maximum number of rating by useres*/
        [HttpGet]
        [Route("MaxPostHasReview")]
        [ProducesResponseType(typeof(List<MaxPostHasReview>), StatusCodes.Status200OK)]
        public List<MaxPostHasReview> MaxPostHasReview()
        {
            return _dTOService.MaxPostHasReview();
        }


        //Search posts by User name or by category title or by post title ((For Clients))

        [HttpGet]
        [Route("PostSearch/{search}")]
        [ProducesResponseType(typeof(List<SearchPostsByClients>), StatusCodes.Status200OK)]

        public List<SearchPostsByClients> SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle(string search)
        {
            return _dTOService.SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle(search);
        }

        //Client Can Display Posts Details 

        [HttpGet]
        [Route("DisplayPost/{id}")]
        [ProducesResponseType(typeof(List<DisplayPostDetails>), StatusCodes.Status200OK)]

        public List<DisplayPostDetails> UserDisplayPostDetails(int id)
        {
            return _dTOService.UserDisplayPostDetails(id);
        }

        //Posts User Liked
        [HttpGet]
        [Route("PostsUserLiked/{id}")]
        [ProducesResponseType(typeof(List<PostUserLiked>), StatusCodes.Status200OK)]

        public List<PostUserLiked> GetPostUserliked(int id)
        {
            return _dTOService.GetPostUserliked(id);
        }

        // Display All Posts image and category and user( name and image ) JOIN
        [HttpGet]
        [Route("DisplayAllPosts")]
        [ProducesResponseType(typeof(List<DisplayAllPosts>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<DisplayAllPosts> DisplayAllPosts()
        {
            return _dTOService.DisplayAllPosts();
        }

        // Display each post with each comments by Id
        [HttpGet]
        [Route("DisplayPostComments/{id}")]
        [ProducesResponseType(typeof(List<DisplayAllPosts>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<DisplayPostComments> DisplayPostComments(int id)
        {
            return _dTOService.DisplayPostComments(id);

        }

        [HttpGet]
        [Route("GetLastesPost")]
        [ProducesResponseType(typeof(List<GetLastesPost>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<GetLastesPost> GetLastesPost()
        {
            return _dTOService.GetLastesPost();
        }

        [HttpGet]
        [Route("DisplayAllPostUser/{id}")]
        [ProducesResponseType(typeof(List<DisplayAllPostUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<DisplayAllPostUser> DisplayAllPostUser(int id)
        {
            return _dTOService.DisplayAllPostUser(id);
        }



    }
}
