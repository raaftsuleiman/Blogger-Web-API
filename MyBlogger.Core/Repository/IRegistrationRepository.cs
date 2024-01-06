using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public interface IRegistrationRepository
    {
        public List<Registreation> GetAll();
        public bool CreateRegistreation(Registreation Registreation);
        public bool UpdateRegistreation(Registreation Registreation);
        public bool DeleteRegistreation(int id);
    }
}
