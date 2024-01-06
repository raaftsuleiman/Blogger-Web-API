using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public class LoginService : ILoginService
    {
        private readonly ILoginRepository  _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository=loginRepository;
        }

        public bool CreateLogin(Login login)
        {
            return _loginRepository.CreateLogin(login);
        }

        public bool DeleteLogin(int id)
        {
            return _loginRepository.DeleteLogin(id);
        }

        public List<Login> GetAllLogin()
        {
            return _loginRepository.GetAllLogin();
        }

        public List<Login> GetLoginDetailsById(int id)
        {
            return _loginRepository.GetLoginDetailsById(id);
        }

        public bool RestPassword(Login login)
        {
            return _loginRepository.RestPassword(login);
        }

        public bool UpdateLogin(Login login)
        {
            return _loginRepository.UpdateLogin(login);
        }
    }
}
