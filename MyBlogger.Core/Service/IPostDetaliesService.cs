using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Service
{
    public interface IPostDetaliesService
    {
        //Function to Get All PostDetalies
        public List<PostDetaly> GetAllDetalies();
        //Function To Create Anew Detalies
        public bool CreateDetalies(PostDetaly postDetaly);
        //Function To Edite Detalies Record 

        public bool UpdateDetalies(PostDetaly postDetaly);
        //Function To Delete Detalies Record 
        public bool DeleteDetalies(int id);
    }
}
