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
    public class TagRepository : ITagRepository
    {
        private readonly IDBcontext _dbcontext;
        public TagRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Function to Get All Tags 
        public List<Tag> GetAllTags()
        {
            IEnumerable<Tag> result = _dbcontext.Connection.Query<Tag>("GetAllTags", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        //Function To Create Anew Tag
        public bool CreateTag(Tag tag)
        {
            var p = new DynamicParameters();
            p.Add("@Title", tag.Title, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@IsPublished", tag.IsPublished, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LastModification", tag.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@metaTitle", tag.MetatTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PublishedOn", tag.PublishedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Slug", tag.Slug, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CreatedOn", tag.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Context", tag.Context, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbcontext.Connection.ExecuteAsync("CreateTag", p, commandType: CommandType.StoredProcedure);
            return true;// I can make it void then dont use return true;

        }

        //Function To Edite Tag Record 

        public bool UpdateTag(Tag tag)
        {
            var p = new DynamicParameters();

            p.Add("@Id", tag.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Title", tag.Title, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@IsPublished", tag.IsPublished, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LastModification", tag.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@metaTitle", tag.MetatTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PublishedOn", tag.PublishedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Slug", tag.Slug, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CreatedOn", tag.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Context", tag.Context, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbcontext.Connection.ExecuteAsync("UpdateTag", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        //Function To Delete Tag Record 
        public bool DeleteTag(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteTag", p, commandType: CommandType.StoredProcedure);

            return true;// I can make it void then dont use return true;

        }
    }
}
