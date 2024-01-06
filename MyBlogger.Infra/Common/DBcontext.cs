using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyBlogger.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace MyBlogger.Infra.Common
{
   public class DBcontext : IDBcontext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;
        public DBcontext(IConfiguration configuration)

        {
            _configuration = configuration;
        }

        public DbConnection Connection
        {
            get

            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_configuration["ConnectionString:DBConnectionString"]);
                    _connection.Open();
                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }

        }
    }
}
