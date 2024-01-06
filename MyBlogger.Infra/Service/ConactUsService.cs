using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class ConactUsService: IConactUsService
    {
        private readonly IConactUsRepository _conactUsRepository;
        public ConactUsService(IConactUsRepository conactUsRepository)
        {
            _conactUsRepository=conactUsRepository;
        }

        public bool CreateContactUs(ContactU contactUs)
        {
            return _conactUsRepository.CreateContactUs(contactUs);
        }

        public bool DeleteContactUs(int id)
        {
            return _conactUsRepository.DeleteContactUs(id);
        }

        public bool UpdateContactUs(ContactU contactUs)
        {
            return _conactUsRepository.UpdateContactUs(contactUs);
        }

        public List<ContactU> GetAllContactUs()
        {
            return _conactUsRepository.GetAllContactUs();
        }

        public List<ContactU> GetDetailsContactUsById(int id)
        {
            return _conactUsRepository.GetDetailsContactUsById(id);
        }
    }
}
