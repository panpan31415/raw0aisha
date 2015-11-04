using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.DAL.Rewrittable
{
    public class AnnotationRepository
    {
        public IEnumerable<Annotation> GetAllannotation(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select date, body from annotation limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var anno in ExecuteQuery(sql))
                yield return anno;
        }
        private static IEnumerable<Annotation> ExecuteQuery(string sql)
        {
            // create the connection
            using (var connection = new MySqlConnection(
                "server=localhost;database=stackoverflow;uid=root;pwd=princess786"))
            {
                // open the connection to the database
                connection.Open();
                // create the command
                var cmd = new MySqlCommand(sql, connection);
                // get the reader (cursor)
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        // return a movie object and yield
                        yield return new Annotation
                        {
                            Date = rdr.GetDateTime(0),
                            Body = rdr.GetString(1),
                       

                        };
                    }
                }
            }
        }
    }
}