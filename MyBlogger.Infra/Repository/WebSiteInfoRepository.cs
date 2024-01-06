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
    public class WebSiteInfoRepository : IWebSiteInfoRepository
    {
        private readonly IDBcontext _dbcontext;
        public WebSiteInfoRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool CreateWebSiteinfo(WebSiteInfo webSiteInfo)
        {
            var p = new DynamicParameters();
            p.Add("@Aboutid", webSiteInfo.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ContactId", webSiteInfo.ContactId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Postid", webSiteInfo.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("CreateWebSiteinfo", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteWebSiteInfo(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteWebSiteInfo", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<WebSiteInfo> GetAllWebSiteInfo()
        {
            IEnumerable<WebSiteInfo> result = _dbcontext.Connection.Query<WebSiteInfo>("GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateWebSiteInfo(WebSiteInfo webSiteInfo)
        {
            var p = new DynamicParameters();
            p.Add("@Id", webSiteInfo.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Aboutid", webSiteInfo.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ContactId", webSiteInfo.ContactId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Postid", webSiteInfo.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("CreateWebSiteinfo", p, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
