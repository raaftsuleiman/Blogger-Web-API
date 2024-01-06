using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public class AboutUsService : IAboutUsService
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }

       public  bool CreateAboutUs(AboutU aboutUs)
        {
            return _aboutUsRepository.CreateAboutUs(aboutUs);
        }

     public   bool  DeleteAboutUs(int id)
        {
            return _aboutUsRepository.DeleteAboutUs(id);
        }

     public   bool UpdateAboutUs(AboutU aboutUs)
        {
            return _aboutUsRepository.UpdateAboutUs(aboutUs);
        }

      public  List<AboutU> GetAllAboutUs()
        {
            return _aboutUsRepository.GetAllAboutUs();
        }

      public   List<AboutU> GetAboutUsById(int id)
        {
            return _aboutUsRepository.GetAboutUsById(id);
                }
    }
}
