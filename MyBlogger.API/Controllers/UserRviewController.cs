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
    public class UserRviewController : Controller
    {
        private readonly IUserReviewService _userReviewService;
        public UserRviewController(IUserReviewService userReviewService)
        {
            _userReviewService = userReviewService;
        }

        [HttpGet]
        public List<UserReview> GetAll()
        {
            return _userReviewService.GetAll();
        }


        [HttpPost]
        public bool CreateUserReview([FromBody] UserReview UserReview)
        {
            return _userReviewService.CreateUserReview(UserReview);
        }

        [HttpPut]
        public bool UpdateUserReview(UserReview UserReview)
        {
            return _userReviewService.UpdateUserReview(UserReview);
        }


        [HttpDelete, Route("delete/{id}")]
        public bool DeleteUserReview(int id)
        {
            return _userReviewService.DeleteUserReview(id);
        }
    }
}
