using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.DAL.ReadOnly
{
    public class CommentRepository
    {
        
            public IEnumerable<Comment> GetAll(int limit = 10, int offset = 0)
            {
                // create the SQL statement
                var sql = string.Format(
                        "select id, text, creationDate from comment limit {0} offset {1}",
                        limit, offset);
                // fetch the selected movies
                foreach (var comment in ExecuteQuery(sql))
                    yield return comment;
            }
            private static IEnumerable<Comment> ExecuteQuery(string sql)
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
                            yield return new Comment
                            {
                                Id = rdr.GetInt32(0),
                                Text = rdr.GetString(1),
                                CreationDate = rdr.GetDateTime(2),

                            };
                        }
                    }
                }
            }
        }
    }
