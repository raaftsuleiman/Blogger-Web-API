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
   public class AboutUsRepository : IAboutUsRepository
    {
        private readonly IDBcontext _dbcontext;
        public AboutUsRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool CreateAboutUs(AboutU aboutUs)
        {

            var p = new DynamicParameters();
            p.Add("@Description", aboutUs.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@image", aboutUs.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateAboutUs", p, commandType: CommandType.StoredProcedure);
            return true;

        }

        public bool DeleteAboutUs(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteAboutUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<AboutU> GetAboutUsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AboutU> result = _dbcontext.Connection.Query<AboutU>("GetDetailsAboutUsById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<AboutU> GetAllAboutUs()
        {
            IEnumerable<AboutU> result = _dbcontext.Connection.Query<AboutU>("GetAllAboutUs", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateAboutUs(AboutU aboutUs)
        {
            var p = new DynamicParameters();
            p.Add("@Id", aboutUs.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Description", aboutUs.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@image", aboutUs.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("UpdateAboutUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

    }
}
