using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public class PostReviewService : IPostReviewService
    {
        private readonly IPostReviewRepository  _postReviewRepository;
        public PostReviewService(IPostReviewRepository postReviewRepository)
        {
            _postReviewRepository=postReviewRepository;
        }

        //Function to Get All Review
        public List<PostReview> GetAllReviwes()
        {
            return _postReviewRepository.GetAllReviwes();
        }
        //Function To Create Anew Review
        public bool CreateReview(PostReview postReview)
        {
            return _postReviewRepository.CreateReview(postReview);
        }
        //Function To Edite Review Record 

        public bool UpdateReview(PostReview postReview)
        {
            return _postReviewRepository.UpdateReview(postReview);
        }
        //Function To Delete Review Record 
        public bool DeleteReview(int id)
        {
            return _postReviewRepository.DeleteReview(id);
        }
    }
}
