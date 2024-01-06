using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public  interface IPostLikesRepository
    {
        //Function to Get Count Of All Likes 
        public int CountOfLikes();

        //Function to Get All Likes
        public List<PostLike> GetAllPostLike();
        //Function To Create Anew Like
        public bool CreateLike(PostLike postLike);
        //Function To Edite Like Record 

        public bool UpdateLike(PostLike postLike);
        //Function To Delete Like Record 
        public bool DeletePostLike(int id);

        //Function To Get Count Of Likes On Posts
        public int CountOfPostLikes(int id);
    }
}
