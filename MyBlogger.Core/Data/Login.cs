using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class Login
    {
       

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int? Userid { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Registreation> Registreations { get; set; }
    }
}
