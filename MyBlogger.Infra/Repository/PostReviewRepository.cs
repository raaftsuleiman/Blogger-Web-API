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
   public class PostReviewRepository : IPostReviewRepository
    {
        private readonly IDBcontext _dbcontext;
        public PostReviewRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Function to Get All Review
        public List<PostReview> GetAllReviwes()
        {
            IEnumerable<PostReview> result = _dbcontext.Connection.Query<PostReview>("GetAllPostReview", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        //Function To Create Anew Review
        public bool CreateReview(PostReview postReview)
        {
            var p = new DynamicParameters();
            p.Add("@Postid", postReview.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@Stars", postReview.Stars, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("CreatePostReview", p, commandType: CommandType.StoredProcedure);
            return true;// I can make it void then dont use return true;

        }

        //Function To Edite Review Record 

        public bool UpdateReview(PostReview postReview)
        {
            var p = new DynamicParameters();
            p.Add("@Id", postReview.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Postid", postReview.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@Stars", postReview.Stars, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UpdatePostReview", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        //Function To Delete Review Record 
        public bool DeleteReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeletePostReview", p, commandType: CommandType.StoredProcedure);

            return true;// I can make it void then dont use return true;

        }
    }
}
