using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
           _registrationRepository=registrationRepository;
        }
        public List<Registreation> GetAll()
        {
            return _registrationRepository.GetAll();
        }


        public bool CreateRegistreation(Registreation Registreation)
        {
            return _registrationRepository.CreateRegistreation(Registreation);
        }
        public bool UpdateRegistreation(Registreation Registreation)
        {
            return _registrationRepository.UpdateRegistreation(Registreation);
        }

        public bool DeleteRegistreation(int id)
        {
            return _registrationRepository.DeleteRegistreation(id);
        }
    }
}
