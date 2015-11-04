using project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project.Controllers
{
    public class PostsController : ApiController
    {
        PostRepository _postRepository = new PostRepository();
        public IEnumerable<Post> Get()
        {
            return _postRepository.GetAll();
        }
    }
}
