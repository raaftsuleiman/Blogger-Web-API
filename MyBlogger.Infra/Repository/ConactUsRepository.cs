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
    public class ConactUsRepository : IConactUsRepository
    {
        private readonly IDBcontext _dbcontext;
        public ConactUsRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool CreateContactUs(ContactU contactUs)
        {
            var p = new DynamicParameters();
            p.Add("@Facebook", contactUs.Facebook, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Instagram", contactUs.Twitter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Text", contactUs.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Image", contactUs.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ContactMobile", contactUs.ContactMobile, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateContactUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteContactUs(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteContactUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ContactU> GetAllContactUs()
        {
            IEnumerable<ContactU> result = _dbcontext.Connection.Query<ContactU>("GetAllContactUs", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ContactU> GetDetailsContactUsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ContactU> result = _dbcontext.Connection.Query<ContactU>("GetDetailsContactUsById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool UpdateContactUs(ContactU contactUs)
        {
            var p = new DynamicParameters();
            p.Add("@Id", contactUs.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Facebook", contactUs.Facebook, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Twitter", contactUs.Twitter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Text", contactUs.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Image", contactUs.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ContactMobile", contactUs.ContactMobile, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateContactUs", p, commandType: CommandType.StoredProcedure);
            return true;

        }
    }
}
