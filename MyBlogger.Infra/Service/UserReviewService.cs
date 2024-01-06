using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
  public  class UserReviewService : IUserReviewService
    {
        private readonly IUserReviewRepository _userReviewRepository;
        public UserReviewService(IUserReviewRepository userReviewRepository)
        {

            _userReviewRepository=userReviewRepository;
        }
        public List<UserReview> GetAll()
        {
            return _userReviewRepository.GetAll();
        }


        public bool CreateUserReview(UserReview UserReview)
        {
            return _userReviewRepository.CreateUserReview(UserReview);
        }
        public bool UpdateUserReview(UserReview UserReview)
        {
            return _userReviewRepository.UpdateUserReview(UserReview);
        }

        public bool DeleteUserReview(int id)
        {
            return _userReviewRepository.DeleteUserReview(id);
        }
    }
}
