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
        AnnotationRepository _annotationRepository = new AnnotationRepository();
        public IEnumerable<AnnotationModel> Getannotation()
        {
            var helper = new UrlHelper(Request);
            return _annotationRepository.GetAllannotation()
                .Select(annotation => ModelFactory.Create(annotation));
        }

        public HttpResponseMessage Post([FromBody] AnnotationModel model)
        {
            var helper = new UrlHelper(Request);
            var annotation = ModelFactory.Parse(model);
            _annotationRepository.Add(annotation);
            return Request.CreateResponse(
                HttpStatusCode.Created
                , ModelFactory.Create(annotation));
        }
    }
}
