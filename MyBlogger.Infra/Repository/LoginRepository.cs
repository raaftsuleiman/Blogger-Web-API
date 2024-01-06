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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDBcontext _dbcontext;
        public LoginRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool CreateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@username", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RoleName", login.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@userid", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("CreateLogin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteLogin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Login> GetAllLogin()
        {
            IEnumerable<Login> result = _dbcontext.Connection.Query<Login>("GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Login> GetLoginDetailsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Login> result = _dbcontext.Connection.Query<Login>("GetLoginDetailsById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool RestPassword(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@userEmail", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@newPassword", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("RestPassword", p, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool UpdateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Id", login.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@username", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RoleName", login.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@userid", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UpdateLogin", p, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
