using project.DAL;
using project.DAL.Rewrittable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace project.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public ModelFactory()
        {
        }

        public PostModel Create(Post post)
            {
            return new PostModel
            {
                Url= _urlHelper.Link("PostApi", new {id= post.Id}),
                Body = post.Body,
                Score= post.Score
            };
            }
        public Post Parse(PostModel model)
        {
            return new Post
            {
                Body= model.Body,
                Score= model.Score
            };
        }


        public AnnotationModel Create(Annotation annotation)
        {
            return new AnnotationModel
            {
                Url = _urlHelper.Link("AnnotationApi", new { PostId = annotation.PostId }),
                Body = annotation.Body,
                Date = annotation.Date
            };
        }
        public Annotation Parse(AnnotationModel model)
        {
            return new Annotation
            {
                Body = model.Body,
                Date = model.Date
            };
        }

    }
}