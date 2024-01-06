using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
    public interface IPostTageRepository
    {
        public List<PostTage> GetAll();
        public bool CreatePostTage(PostTage PostTage);
        public bool UpdatePostTage(PostTage PostTage);
        public bool DeletePostTage(int id);
    }
}
