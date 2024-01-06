using Dapper;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.Common;
using MyBlogger.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyBlogger.Infra.Repository
{
   public class UsersRepository : IUserRepository
    {
        private readonly IDBcontext _dbcontext;
        public UsersRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //Function to Get Count Of All Users 
        string sql = "SELECT * FROM Users";

        public int CountOfUsers()
        {
            var result = _dbcontext.Connection.Query<User>(sql).Count();
            return result;
        }

        //Function to Get All Users 
        public List<User> GetAllUsers()
        {
            IEnumerable<User> result = _dbcontext.Connection.Query<User>("GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        //Function to Get Last  User
        public List<User> GetLastUser()
        {
            IEnumerable<User> result =  _dbcontext.Connection.Query<User>("Select Top 1(Id) From Users order by  Id desc", commandType: CommandType.Text);
            return result.ToList();

        }

        //Function to Get User By Id
        public List<User> GetUserById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbcontext.Connection.Query<User>("GetUserById",p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        //Function To Create Anew User
        public bool CreateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Image", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastLogin", user.LastLogin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Lastname", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Mobile", user.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Fname", user.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RegisterdAt", user.RegisterdAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@ProfileDescription", user.ProfileDescription, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = _dbcontext.Connection.ExecuteAsync("CreateUesr", p, commandType: CommandType.StoredProcedure);
            return true;// I can make it void then dont use return true;

        }

        //Function To Edite User Record 

        public bool UpdateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Id", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@Image", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastLogin", user.LastLogin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Lastname", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Mobile", user.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Fname", user.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RegisterdAt", user.RegisterdAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@ProfileDescription", user.ProfileDescription, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = _dbcontext.Connection.ExecuteAsync("UpdateUser", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        //Function To Delete User Record 
        public bool DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteUser", p, commandType: CommandType.StoredProcedure);

            return true;// I can make it void then dont use return true;

        }

        //Function To Search About User 
        public List<User> SearchAboutUserByFnameLnameOrEmail(string search)
        {
            var p = new DynamicParameters();
            p.Add("@search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<User> result = _dbcontext.Connection.Query<User>("SearchAboutUserByFnameLnameOrEmail", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> CheckByEmail(string email)
        {
            var p = new DynamicParameters();
            p.Add("@Email", email, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<User> result = _dbcontext.Connection.Query<User>("CheckByEmail", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
