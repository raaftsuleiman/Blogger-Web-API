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
    public class RegistrationRepository: IRegistrationRepository
    {
        private readonly IDBcontext _dbcontext;
        public RegistrationRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Registreation> GetAll()
        {
            IEnumerable<Registreation> result = _dbcontext.Connection.Query<Registreation>("GetAllRegistreation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateRegistreation(Registreation Registreation)
        {
            var p = new DynamicParameters();
            p.Add("@username", Registreation.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@password", Registreation.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@LoginId", Registreation.LoginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateRegistreation", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateRegistreation(Registreation Registreation)
        {
            var p = new DynamicParameters();
            p.Add("@RegistreationId", Registreation.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@username", Registreation.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@password", Registreation.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LoginId", Registreation.LoginId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UpdateRegistreation", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteRegistreation(int id)
        {
            var p = new DynamicParameters();
            p.Add("@RegistreationId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteRegistreation", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }

}
