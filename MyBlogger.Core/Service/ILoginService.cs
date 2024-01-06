using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Service
{
    public interface ILoginService
    {
        public bool CreateLogin(Login login);

        public bool DeleteLogin(int id);

        public bool RestPassword(Login login);
        public bool UpdateLogin(Login login);

        public List<Login> GetAllLogin();

        public List<Login> GetLoginDetailsById(int id);
    }
}
