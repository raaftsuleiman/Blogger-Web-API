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
   public class PostDetaliesRepository : IPostDetaliesRepository
    {
        private readonly IDBcontext _dbcontext;
        public PostDetaliesRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Function to Get All PostDetalies
        public List<PostDetaly> GetAllDetalies()
        {
            IEnumerable<PostDetaly> result = _dbcontext.Connection.Query<PostDetaly>("GetAllpostDetalies", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        //Function To Create Anew Detalies
        public bool CreateDetalies(PostDetaly postDetaly)
        {
            var p = new DynamicParameters();
            p.Add("@IsLiked", postDetaly.Descreption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Postid", postDetaly.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbcontext.Connection.ExecuteAsync("CreatePostDetalies", p, commandType: CommandType.StoredProcedure);
            return true;// I can make it void then dont use return true;

        }
        //Function To Edite Detalies Record 

        public bool UpdateDetalies(PostDetaly postDetaly)
        {
            var p = new DynamicParameters();
            p.Add("@IsLiked", postDetaly.Descreption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Postid", postDetaly.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Id", postDetaly.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("UpdateDetalies", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        //Function To Delete Detalies Record 
        public bool DeleteDetalies(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeletepostDetalies", p, commandType: CommandType.StoredProcedure);

            return true;// I can make it void then dont use return true;

        }
    }
}
