using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class PostTagService : IPostTagService
    {
        private readonly IPostTageRepository _postTageRepository;
        public PostTagService(IPostTageRepository postTageRepository)
        {
            _postTageRepository = postTageRepository;
        }
        public List<PostTage> GetAll()
        {
            return _postTageRepository.GetAll();
        }


        public bool CreatePostTage(PostTage PostTage)
        {
            return _postTageRepository.CreatePostTage(PostTage);
        }
        public bool UpdatePostTage(PostTage PostTage)
        {
            return _postTageRepository.UpdatePostTage(PostTage);
        }

        public bool DeletePostTage(int id)
        {
            return _postTageRepository.DeletePostTage(id);
        }
    }
}
