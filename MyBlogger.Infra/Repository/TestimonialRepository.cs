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
    public class TestimonialRepository: ITestimonialRepository
    {
        private readonly IDBcontext _dbcontext;
        public TestimonialRepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Testimonial> GetAll()
        {
            IEnumerable<Testimonial> result = _dbcontext.Connection.Query<Testimonial>("GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("@FeedBack", testimonial.FeedBack, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserId", testimonial.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("CreateTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("@TestimonialId", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FeedBack", testimonial.FeedBack, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserId", testimonial.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbcontext.Connection.ExecuteAsync("DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Testimonial> GetTestimonialbyId(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Testimonial> result = _dbcontext.Connection.Query<Testimonial>("GetTestimonialbyId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
