using System;
using System.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;

namespace QueryFilter.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlBuilder = new SqlBuilder();
            var filter = "<=5 && > 2 || == 7";
            var query = @"
SELECT *
FROM sys.databases
/**where**/";
            var selector = sqlBuilder.AddTemplate(query);
            var filterBuilder = new FilterActionBuilder();
            filterBuilder.BuildFilter(sqlBuilder, filter, "database_id");

            using (var connection = new SqlConnection(@"Server=.\SQLExpress;Database=master;Trusted_Connection=True;"))
            {
                var result = connection.Query(selector.RawSql, selector.Parameters);
                /*
                   SELECT 
                   FROM sys.databases
                   WHERE database_id <= 5 AND  ( database_id > 2 OR database_id = 7 ) 
                 */
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
        }
    }
}
