using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.DTO
{
    public class DisplayPostDetails
    {
        public DateTime? CreateAt { get; set; }

        public string Descreption { get; set; }

        public string Title { get; set; }

        public string Fname { get; set; }

        public string LastName { get; set; }

    }
}