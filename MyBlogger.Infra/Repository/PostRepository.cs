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
    public class PostRepository : IPostRepository
    {
        private readonly IDBcontext _dbcontext;
        public PostRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //Function to Get Count Of All Posts 
        string sql = "SELECT * FROM Post";

        public int  CountOfPost()
        {
            var  result = _dbcontext.Connection.Query<Post>(sql).Count();
            return result;
        }

          // Function to  Get Lastes 5 postes (Title and Contant )
        public List<Post> GetLastesPost()
        {
            IEnumerable<Post> result = _dbcontext.Connection.Query<Post>("GetLastesPost", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        // Function to  Get Lastes 5 postes
        public List<Post> GetTop5()
        {
            IEnumerable<Post> result = _dbcontext.Connection.Query<Post>("SELECT TOP 6* FROM Post ", commandType: CommandType.Text);
            return result.ToList();

        }
        public bool CreatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@Slug", post.Slug, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Title", post.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Image", post.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Published", post.Published, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CreateAt", post.CreateAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@UpdateAt", post.UpdateAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PostContant", post.PostContant, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastModification", post.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@CategoreId", post.CategoreId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@userid", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreatePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletePost(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeletePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Post> GetAllPost()
        {
            IEnumerable<Post> result = _dbcontext.Connection.Query<Post>("GetAllPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Post> GetPostDetailsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Post> result = _dbcontext.Connection.Query<Post>("GetPostDetailsById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@Id", post.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Slug", post.Slug, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Title", post.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Image", post.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Published", post.Published, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CreateAt", post.CreateAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@UpdateAt", post.UpdateAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PostContant", post.PostContant, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastModification", post.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@CategoreId", post.CategoreId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@userid", post.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("UpdatePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Remove All Post Befor specific Date
        public bool RemoveAllPostBeforDate(DateTime Date)
        {
            var p = new DynamicParameters();
            p.Add("@Date", Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("RemoveAllPostBeforDate", p, commandType: CommandType.StoredProcedure);

            return true;

        }
        // Remove All post has Negative Rate (stares < =2)
        public bool RemoveAllposthasNegativeRate()
        {
            var result = _dbcontext.Connection.Query("RemoveAllposthasNegativeRate",  commandType: CommandType.StoredProcedure);

            return true;
        }
     

    }
}
