using MyBlogger.API.Core.Data;
using MyBlogger.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
 public   interface IJwtRepositorycs
    {
        public Login auth(Login login);
    }
}
