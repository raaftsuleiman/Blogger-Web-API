using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Service
{
    public interface IUsersService
    {
        //Function to Get Count Of All Users 
        public int CountOfUsers();

        //Function to Get All Users 
        public List<User> GetAllUsers();
        //Function To Create Anew User
        public bool CreateUser(User user);

        //Function To Edite User Record 

        public bool UpdateUser(User user);

        //Function To Delete User Record 
        public bool DeleteUser(int id);


        //Function To Search About User 
        public List<User> SearchAboutUserByFnameLnameOrEmail(string search);
        //Function to Get User By Id
        public List<User> GetUserById(int Id);

        public List<User> CheckByEmail(string email);
        //Function to Get Last  User
        public List<User> GetLastUser();
    }
}
