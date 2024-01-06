using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public interface IUserReviewRepository
    {
        public List<UserReview> GetAll();
        public bool CreateUserReview(UserReview UserReview);
        public bool UpdateUserReview(UserReview UserReview);
        public bool DeleteUserReview(int id);
    }
}
