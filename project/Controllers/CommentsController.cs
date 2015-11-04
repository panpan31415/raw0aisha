using project.DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project.Controllers
{
    public class CommentsController : ApiController
    {
       CommentRepository _commentRepository = new CommentRepository();
        public IEnumerable<Comment> Get()
        {
            return _commentRepository.GetAll();
        }
    }
}
