using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Service
{
   public interface ITagService
    {

        //Function to Get All Tags 
        public List<Tag> GetAllTags();
        //Function To Create Anew Tag
        public bool CreateTag(Tag tag);


        //Function To Edite Tag Record 

        public bool UpdateTag(Tag tag);
        //Function To Delete Tag Record 
        public bool DeleteTag(int id);
    }
}
