using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository=postRepository;
        }
        //Function to Get Count Of All Posts 
        public int CountOfPost()
        {
            return _postRepository.CountOfPost();
        }

        // Function to  Get Lastes 5 postes (Title and Contant )
        public List<Post> GetLastesPost()
        {
            return _postRepository.GetLastesPost();
        }
        public bool CreatePost(Post post)
        {
            return _postRepository.CreatePost(post);
        }

        public bool DeletePost(int id)
        {
            return _postRepository.DeletePost(id);
        }

        public List<Post> GetAllPost()
        {
            return _postRepository.GetAllPost();
        }

        public List<Post> GetPostDetailsById(int id)
        {
            return _postRepository.GetPostDetailsById(id);
        }

        public bool UpdatePost(Post post)
        {
            return _postRepository.UpdatePost(post);
        }

        //Remove All Post Befor specific Date
        public bool RemoveAllPostBeforDate(DateTime Date)
        {
            return _postRepository.RemoveAllPostBeforDate(Date);
        }
        // Remove All post has Negative Rate (stares < =2)
        public bool RemoveAllposthasNegativeRate()
        {
            return _postRepository.RemoveAllposthasNegativeRate();
        }

        // Function to  Get Lastes 5 postes
        public List<Post> GetTop5()
        {
            return _postRepository.GetTop5();
        }



    }
}
