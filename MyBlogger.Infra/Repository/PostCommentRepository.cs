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
   public class PostCommentRepository : IPostCommentRepository
    {
        private readonly IDBcontext _dbcontext;
        public PostCommentRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Function to Get Count Of All Comment 
        string sql = "SELECT * FROM PostComment";

        public int CountOfComments()
        {
            var result = _dbcontext.Connection.Query<PostComment>(sql).Count();
            return result;
        }

        //Function to Get All Comment
        public List<PostComment> GetAllComments()
        {
            IEnumerable<PostComment> result = _dbcontext.Connection.Query<PostComment>("GetAllComment", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        //Function To Create Anew PostComment
        public bool CreateComment(PostComment postComment)
        {
            var p = new DynamicParameters();
            p.Add("@IsPublished", postComment.IsPublished, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LastModification", postComment.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Postid", postComment.Postid ,dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Userid", postComment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PublishedAt", postComment.PublishedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@CreateAt", postComment.CreateAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Content", postComment.Content, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbcontext.Connection.ExecuteAsync("CreatePostComment", p, commandType: CommandType.StoredProcedure);
            return true;// I can make it void then dont use return true;

        }

        //Function To Edite PostComment Record 

        public bool UpdateComment(PostComment postComment)
        {
            var p = new DynamicParameters();
            p.Add("@Id", postComment.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@IsPublished", postComment.IsPublished, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LastModification", postComment.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Postid", postComment.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Userid", postComment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PublishedAt", postComment.PublishedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@CreateAt", postComment.CreateAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Content", postComment.Content, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UpdateComment", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        //Function To Delete Comment Record 
        public bool DeleteComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteComment", p, commandType: CommandType.StoredProcedure);

            return true;// I can make it void then dont use return true;

        }

        public bool UserUpdateHisComment(PostComment postComment)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", postComment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Content", postComment.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PostId", postComment.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UserUpdateHisComment", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        string SQl = "Select Id As Comments From PostComment Where Postid = @PostId";
        //Function To Get Count Of Comment On Posts
        public int CountOfPostComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("@PostId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.Query<PostComment>(SQl, p).Count();
            return result;

        }
        public List<PostComment> GetCommentByUserIdAndPostId(int userid, int postid)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PostId", postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostComment> result = _dbcontext.Connection.Query<PostComment>("GetCommentByUserIdAndPostId",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool UserDeleteHisComment( int UserId, int PostId)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PostId", PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UserDeleteHisComment", p, commandType: CommandType.StoredProcedure);

            return true;

        }





    }
}
