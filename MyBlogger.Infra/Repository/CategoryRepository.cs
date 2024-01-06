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
   public class CategoryRepository : ICategoryRepository
    {
        private readonly IDBcontext _dbcontext;
        public CategoryRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@Title", category.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@metaTitle", category.MetaTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Slug", category.Slug, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Content", category.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastModification", category.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = _dbcontext.Connection.Query<Category>("GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Category> GetCategoryDetailsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = _dbcontext.Connection.Query<Category>("GetCategoryDetailsById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@Id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Title", category.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@metaTitle", category.MetaTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Slug", category.Slug, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Content", category.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@LastModification", category.LastModification, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("UpdateCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        //Search Category  By its ID or Title 
        public List<Category> SearchCategoryByIdOrTitle(string search)
        {


            var p = new DynamicParameters();

            p.Add("@search", search, dbType: DbType.String, direction: ParameterDirection.Input);


            IEnumerable<Category> result = _dbcontext.Connection.Query<Category>("SearchCategoryByIdOrTitle", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
