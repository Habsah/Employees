using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Employees.Services
{
    public interface IRepository
    {
        T Get<T>(string sqlCommand);
        List<T> GetAll<T>(string sqlCommand);
        int Execute(string sqlCommand);
    }

    public class Repository : IRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString = "DefaultConnection";

        public Repository(IConfiguration config)
        {
             _config = config;
        }

        public int Execute(string sqlCommand)
        {
            using IDbConnection db = GetDbConnection();
            return db.Execute(sqlCommand);
        }

        public T Get<T>(string sqlCommand)
        {
            using IDbConnection db = GetDbConnection();
            return db.Query<T>(sqlCommand).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sqlCommand)
        {
            using IDbConnection db = GetDbConnection();
            return db.Query<T>(sqlCommand).ToList();
        }

        public DbConnection GetDbConnection() => new SqlConnection(_config.GetConnectionString(_connectionString));
    }
}
