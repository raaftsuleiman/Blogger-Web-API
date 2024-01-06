using System;
using System.Collections.Generic;
using MyBlogger.API.Core.Data;



namespace MyBlogger.API.Core.Data
{
    public partial class Registreation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? LoginId { get; set; }

        public virtual Login Login { get; set; }
    }
}
