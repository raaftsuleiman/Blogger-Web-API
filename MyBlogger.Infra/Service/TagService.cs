using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            
            _tagRepository=tagRepository;
        }

        //Function to Get All Tags 
        public List<Tag> GetAllTags()
        {
            return _tagRepository.GetAllTags();
        }
        //Function To Create Anew Tag
        public bool CreateTag(Tag tag)
        {
            return _tagRepository.CreateTag(tag);
        }


        //Function To Edite Tag Record 

        public bool UpdateTag(Tag tag)
        {
            return _tagRepository.UpdateTag(tag);
        }
        //Function To Delete Tag Record 
        public bool DeleteTag(int id)
        {
            return _tagRepository.DeleteTag(id);
        }
    }
}
