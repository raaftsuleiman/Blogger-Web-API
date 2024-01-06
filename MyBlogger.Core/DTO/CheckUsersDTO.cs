using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
   public class CheckUsersDTO
    {
        public string email { get; set; }

        public string username { get; set; }

        public int code { get; set; }

        public string FullName { get; set; }
    }
}
