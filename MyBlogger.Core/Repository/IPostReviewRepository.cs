using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public interface IPostReviewRepository
    {

        //Function to Get All Review
        public List<PostReview> GetAllReviwes();
        //Function To Create Anew Review
        public bool CreateReview(PostReview postReview);
        //Function To Edite Review Record 

        public bool UpdateReview(PostReview postReview);
        //Function To Delete Review Record 
        public bool DeleteReview(int id);
    }
}
