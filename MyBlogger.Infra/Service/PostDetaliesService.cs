using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class PostDetaliesService : IPostDetaliesService
    {
        private readonly IPostDetaliesRepository _postDetaliesRepository;
        public PostDetaliesService(IPostDetaliesRepository postDetaliesRepository)
        {
            _postDetaliesRepository = postDetaliesRepository;
        }


        //Function to Get All PostDetalies
        public List<PostDetaly> GetAllDetalies()
        {
            return _postDetaliesRepository.GetAllDetalies();
        }
        //Function To Create Anew Detalies
        public bool CreateDetalies(PostDetaly postDetaly)
        {
            return _postDetaliesRepository.CreateDetalies(postDetaly);
        }
        //Function To Edite Detalies Record 

        public bool UpdateDetalies(PostDetaly postDetaly)
        {
            return _postDetaliesRepository.UpdateDetalies(postDetaly);
        }
        //Function To Delete Detalies Record 
        public bool DeleteDetalies(int id)
        {
            return _postDetaliesRepository.DeleteDetalies(id);
        }

    }
}
