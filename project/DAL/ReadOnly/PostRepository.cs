using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.DAL
{
    public class PostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select id, body, score from post limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }
        private static IEnumerable<Post> ExecuteQuery(string sql)
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
                        yield return new Post
                        {
                            Id = rdr.GetInt32(0),
                            Body = rdr.GetString(1),
                            Score = rdr.GetInt32(2),

                        };
                    }
                }
            }
        }
    }
}