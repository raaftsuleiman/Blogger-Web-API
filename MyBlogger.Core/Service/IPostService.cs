using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Service
{
    public interface IPostService
    {
        //Function to Get Count Of All Posts 
        public int CountOfPost();

        // Function to  Get Lastes 5 postes (Title and Contant )
        public List<Post> GetLastesPost();

        public bool CreatePost(Post post);

        public bool DeletePost(int id);

        public bool UpdatePost(Post post);

        public List<Post> GetAllPost();

        public List<Post> GetPostDetailsById(int id);

        //Remove All Post Befor specific Date
        public bool RemoveAllPostBeforDate(DateTime Date);
        // Remove All post has Negative Rate (stares < =2)
        public bool RemoveAllposthasNegativeRate();


        // Function to  Get Lastes 5 postes
        public List<Post> GetTop5();


    }

}
