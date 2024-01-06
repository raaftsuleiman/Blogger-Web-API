using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.DTO;
using MyBlogger.Core.Common;

namespace MyBlogger.Core.Repository


{
    public class JwtRepository : IJwtRepositorycs
    {
        private readonly IDBcontext dBContext;

        public JwtRepository(IDBcontext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Login auth(Login login)
        {

            var p = new DynamicParameters();
            p.Add("@UserName", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = dBContext.Connection.Query<Login>("LoginUser", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
