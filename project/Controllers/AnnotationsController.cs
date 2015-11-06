using project.DAL.Rewrittable;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace project.Controllers
{
    public class AnnotationsController : BaseApiController
    {
         AnnotationRepository _annoRepository = new AnnotationRepository();
        //ModelFactory _modelFactory = new ModelFactory();
        public IEnumerable<AnnotationModel> Get()
        {
            var helper = new UrlHelper(Request);
            return _annoRepository.GetAllannotation()
                .Select(annotation => ModelFactory.Create(annotation));
        }

        public HttpResponseMessage annotation([FromBody] AnnotationModel model)
        {
            var helper = new UrlHelper(Request);
            var annotation = ModelFactory.Parse(model);
            _annoRepository.Add(annotation);
            return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(annotation));
        }

        public HttpResponseMessage put(int PostId, [FromBody] AnnotationModel model)
        {
            var helper = new UrlHelper(Request);
            var annotation = ModelFactory.Parse(model);
            annotation.PostId = PostId;
            _annoRepository.Update(annotation);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
