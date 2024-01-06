using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {

           _userRepository=userRepository;
        }
        //Function to Get Count Of All Users 
        public int CountOfUsers()
        {
            return _userRepository.CountOfUsers();
        }

        //Function to Get All Users 
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();

        }

        //Function To Create Anew User
        public bool CreateUser(User user)
        {
            return _userRepository.CreateUser(user);

        }

        //Function To Edite User Record 

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        //Function To Delete User Record 
        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }


        //Function To Search About User 
        public List<User> SearchAboutUserByFnameLnameOrEmail(string search)
        {
            return _userRepository.SearchAboutUserByFnameLnameOrEmail(search);
        }

        //Function to Get User By Id
        public List<User> GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }

        //Function to Get Last  User
        public List<User> GetLastUser()
        {
            return _userRepository.GetLastUser();
        }

        public List<User> CheckByEmail(string email)
        {
            return _userRepository.CheckByEmail(email);
        }
    }


}
