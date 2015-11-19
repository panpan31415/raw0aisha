using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
namespace project.DAL.ReadOnly
{
    public class CommentRepository : abstractRepository<Comment>
    {

        public override IEnumerable<Comment> get(int limit = 10, int offset = 0)
        {
            return getByAttribute(null);
        }

        public override Comment getById(int id)
        {
            var Comments = getByAttribute(Tuple.Create("Id", (object)id));
            if (Comments.Count() > 1)
            {
                throw new OutOfMemoryException("there are more than 1 element get by the given id, check database unique constraint!");
            }
            else if (Comments.Count() == 1)
            {
                Comment c = Comments.First();
                return c;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Comment> getByPostId(int postId)
        {
            return getByAttribute(Tuple.Create("PostId", (object)postId));
        }
        public IEnumerable<Comment> getByUserId(int userId)
        {
            return getByAttribute(Tuple.Create("userID", (object)userId));
        }
        public IEnumerable<Comment> getBycreationDate( DateTime creationDate)
        {
            return getByAttribute(Tuple.Create("creationDate", (object)creationDate));
        }
        public IEnumerable<Comment> getByKeyWord(String keyword)
        {
            return getByAttribute(Tuple.Create("Text", (object)keyword));
        }




        private IEnumerable<Comment> getByAttribute(Tuple<string, object> attribut_value)
        {
            string sql;
            switch (attribut_value.Item1)
            {
                case "Id":
                    sql = string.Format("select * from comment where id = {0}",
                    (int)attribut_value.Item2);
                    break;
                case "PostId":
                    sql = string.Format("select * from comment where postId = {0}",
                    (int)attribut_value.Item2);
                    break;
                case "userID":
                    sql = string.Format("select * from comment where userid = {0}",
                    (int)attribut_value.Item2);
                    break;
                case "creationDate":
                    sql = string.Format("select * from comment where creationDate = {0:yyyy-mm-dd hh-mm-ss}",
                    (DateTime)attribut_value.Item2);
                    break;
                case "Text":
                    sql = string.Format("select * from comment where text like %{0}%",
                    (string)attribut_value.Item2);
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
