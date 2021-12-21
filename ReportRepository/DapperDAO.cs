using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportRepository
{
    public static class DapperDAO
    {

        private static SqlConnection getConnection(string appName, IConfiguration config)
        {
            string connectionString = config.GetConnectionString(appName);
            SqlConnection con = new(connectionString);
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return con;

        }
        public static object ExecuteQuery<T>(string sqlQuery, string appName, IConfiguration configuration)
        {
            //T? model = default;
            using var connection = getConnection(appName, configuration);
            var tables = connection.Query<T>(sqlQuery).ToList();
            //var result = connection.Query<DataTable>("select * from Products").ToList();
            //var orderDetail = connection.QueryFirstOrDefault<string>(sqlOrderDetail, new { OrderDetailID = 1 });
            //var affectedRows = connection.Execute(sqlCustomerInsert, new { CustomerName = "Mark" });



            //return (T)(object)tables;

            return tables;
        }
    }
}
