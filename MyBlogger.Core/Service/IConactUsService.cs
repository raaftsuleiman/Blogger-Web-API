using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Service
{
    public interface IConactUsService
    {
       public bool CreateContactUs(ContactU contactUs);

       public bool DeleteContactUs(int id);

       public bool UpdateContactUs(ContactU contactUs);

       public List<ContactU> GetAllContactUs();

       public List<ContactU> GetDetailsContactUsById(int id);
    }
}
