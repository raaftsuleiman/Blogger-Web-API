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
   public class PostTageRepository : IPostTageRepository
    {
        private readonly IDBcontext _dbcontext;
        public PostTageRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<PostTage> GetAll()
        {
            IEnumerable<PostTage> result = _dbcontext.Connection.Query<PostTage>("GetAllPostTage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreatePostTage(PostTage PostTage)
        {
            var p = new DynamicParameters();
            p.Add("@Postid", PostTage.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@TageId", PostTage.TageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreatePostTage", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdatePostTage(PostTage PostTage)
        {
            var p = new DynamicParameters();
            p.Add("@PostTageId", PostTage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Postid", PostTage.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@TageId", PostTage.TageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("UpdatePostTage", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletePostTage(int id)
        {
            var p = new DynamicParameters();
            p.Add("@PostTageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeletePostTage", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
