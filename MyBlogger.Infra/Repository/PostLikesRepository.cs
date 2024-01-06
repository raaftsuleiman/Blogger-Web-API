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
    public class PostLikesRepository : IPostLikesRepository
    {
        private readonly IDBcontext _dbcontext;
        public PostLikesRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Function to Get Count Of All Likes 
        string sql = "SELECT * FROM PostLikes where PostLikes.IsLiked=1";

        public int CountOfLikes()
        {
            var result = _dbcontext.Connection.Query<PostLike>(sql).Count();
            return result;
        }

        //Function to Get All Likes
        public List<PostLike> GetAllPostLike()
        {
            IEnumerable<PostLike> result = _dbcontext.Connection.Query<PostLike>("GetAllLikes", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        //Function To Create Anew Like
        public bool CreateLike(PostLike postLike)
        {
            var p = new DynamicParameters();
            p.Add("@IsLiked", postLike.IsLiked, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Postid", postLike.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Userid", postLike.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbcontext.Connection.ExecuteAsync("CreatePostLikes", p, commandType: CommandType.StoredProcedure);
            return true;// I can make it void then dont use return true;

        }

        //Function To Edite Like Record 

        public bool UpdateLike(PostLike postLike)
        {
            var p = new DynamicParameters();
            p.Add("@Id", postLike.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@IsLiked", postLike.IsLiked, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Postid", postLike.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Userid", postLike.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbcontext.Connection.ExecuteAsync("UpdatePostLikes", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        //Function To Delete Like Record 
        public bool DeletePostLike(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeletePostLikes", p, commandType: CommandType.StoredProcedure);

            return true;// I can make it void then dont use return true;

        }

        string SQl = "Select Id As Likes From PostLikes Where Postid = @PostId";

        //Function To Get Count Of Likes On Posts
        public int CountOfPostLikes(int id)
        {
            var p = new DynamicParameters();
            p.Add("@PostId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.Query<PostLike>("Select Postid, Id As Likes From PostLikes Where Postid = @PostId ", p).Count();
            return result;
        }

    }
}
