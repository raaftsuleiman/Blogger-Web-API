using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class PostLikesService : IPostLikesService
    {
        private readonly IPostLikesRepository _postLikesRepository;
        public PostLikesService(IPostLikesRepository postLikesRepository)
        {
            _postLikesRepository = postLikesRepository;
        }

        //Function to Get Count Of All Likes 
        public int CountOfLikes()
        {
            return _postLikesRepository.CountOfLikes();
        }

        //Function to Get All Likes
        public List<PostLike> GetAllPostLike()
        {
            return _postLikesRepository.GetAllPostLike();
        }
        //Function To Create Anew Like
        public bool CreateLike(PostLike postLike)
        {
            return _postLikesRepository.CreateLike(postLike);
        }
        //Function To Edite Like Record 

        public bool UpdateLike(PostLike postLike)
        {
            return _postLikesRepository.UpdateLike(postLike);
        }
        //Function To Delete Like Record 
        public bool DeletePostLike(int id)
        {
            return _postLikesRepository.DeletePostLike(id);
        }


        //Function To Get Count Of Likes On Posts
        public int CountOfPostLikes(int id)
        {
            return _postLikesRepository.CountOfPostLikes(id);
        }
    }
}