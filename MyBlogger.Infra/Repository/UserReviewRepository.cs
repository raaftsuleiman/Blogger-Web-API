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
   public class UserReviewRepository : IUserReviewRepository
    {
        private readonly IDBcontext _dbcontext;
        public UserReviewRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<UserReview> GetAll()
        {
            IEnumerable<UserReview> result = _dbcontext.Connection.Query<UserReview>("GetAllUserReview", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateUserReview(UserReview UserReview)
        {
            var p = new DynamicParameters();
            p.Add("@Stars", UserReview.Stars, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@userid", UserReview.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateUserReview", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateUserReview(UserReview UserReview)
        {
            var p = new DynamicParameters();
            p.Add("@UserReviewId", UserReview.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Stars", UserReview.Stars, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserId", UserReview.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("UpdateUserReview", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteUserReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("@UserReviewId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteUserReview", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
