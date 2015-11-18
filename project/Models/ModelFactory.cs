using project.DAL;
using project.DAL.ReadOnly;
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
                Url= _urlHelper.Link("PostApi", new {PostId= post.Id}),
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
        public CommentModel Create(Comment comment)
        {
            return new CommentModel
            {
                PostId = comment.PostId,
                creationDate = comment.CreationDate,
                text = comment.Text,
                userid = comment.Userid
            };
        }

        public Comment Parse(CommentModel model)
        {
            return new Comment
            {
                Userid = model.userid,
                CreationDate = model.creationDate,
                PostId = model.postId,
                Text = model.text
            };
        }

    }
}