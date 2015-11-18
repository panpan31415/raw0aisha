using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace project.DAL.ReadOnly
{
    public class CommentRepository : abstractRepository<Comment>
    {

        public CommentRepository()
        {

        }
        public override IEnumerable<Comment> getAll(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select * from comment limit {0} offset {0}",
                    limit, offset);
            using (MySqlDataReader rdr = dataReader(sql))
            {
                while (rdr.HasRows && rdr.Read())
                {
                    int id = 0;
                    int postId = 0;
                    string text = "no text";
                    DateTime creationDate = DateTime.Now;
                    int userid = 0;
                    //check nulls 
                    if (!rdr.IsDBNull(0))
                        id = rdr.GetInt32(0);
                    if (!rdr.IsDBNull(1))
                        postId = rdr.GetInt32(1);
                    if (!rdr.IsDBNull(2))
                        text = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                        creationDate = rdr.GetDateTime(3);
                    if (!rdr.IsDBNull(4))
                        userid = rdr.GetInt32(4);

                    yield return new Comment
                    {
                        Id = id,
                        PostId = postId,
                        Text = text,
                        CreationDate = creationDate,
                        Userid = userid,
                    };
                }
            }

        }

        public override Comment getById(int id)
        {
            return getBySingleAttribute(Tuple.Create("Id", (object)id));
        }

        public IEnumerable<Comment> getByPostId(int postId)
        {
            return getBySingleAttribute(Tuple.Create("PostId", (object)postId));
        }

       

        private IEnumerable<Comment> getBySingleAttribute(Tuple<string, object> attribut_value)
        {
            string sql;
            switch (attribut_value.Item1)
            {
                case "Id":
                    sql = string.Format("select * from comment where id = {0}",
                    attribut_value.Item2);
                    break;
                case "PostId":
                    sql = string.Format("select * from comment where postId = {0}",
                    attribut_value.Item2);
                    break;
                case "userID":
                    sql = string.Format("select * from comment where userid = {0}",
                    attribut_value.Item2);
                    break;
                case "creationDate":
                    sql = string.Format("select * from comment where creationDate = {0}",
                    attribut_value.Item2);
                    break;
                case "Text":
                    sql = string.Format("select * from comment where text like %{0}%",
                    attribut_value.Item2);
                    break;
                default:
                    throw new ArgumentException("You must specify a correct attribute value");                    
            }
            using (MySqlDataReader rdr = dataReader(sql))
            {
                while (rdr.HasRows && rdr.Read())
                {
                    int id = 0;
                    int postId = 0;
                    string text = "no text";
                    DateTime creationDate = DateTime.Now;
                    int userid = 0;
                    //check nulls 
                    if (!rdr.IsDBNull(0))
                        id = rdr.GetInt32(0);
                    if (!rdr.IsDBNull(1))
                        postId = rdr.GetInt32(1);
                    if (!rdr.IsDBNull(2))
                        text = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                        creationDate = rdr.GetDateTime(3);
                    if (!rdr.IsDBNull(4))
                        userid = rdr.GetInt32(4);

                    yield return new Comment
                    {
                        Id = id,
                        PostId = postId,
                        Text = text,
                        CreationDate = creationDate,
                        Userid = userid,
                    };
                }
            }

        }
    }
}
