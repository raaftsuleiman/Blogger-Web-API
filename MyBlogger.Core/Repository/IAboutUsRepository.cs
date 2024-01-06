using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public interface IAboutUsRepository
    {

       public bool CreateAboutUs(AboutU aboutUs);

      public   bool DeleteAboutUs(int id);

      public  bool UpdateAboutUs(AboutU aboutUs);

      public  List<AboutU> GetAllAboutUs();

       public  List<AboutU> GetAboutUsById(int id);
    }
}
