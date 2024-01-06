using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
   public  interface ILoginRepository
    {
        public bool CreateLogin(Login login);

        public bool DeleteLogin(int id);

        public bool UpdateLogin(Login login);

        public bool RestPassword(Login login);

        public List<Login> GetAllLogin();

        public List<Login> GetLoginDetailsById(int id);
    }
}
