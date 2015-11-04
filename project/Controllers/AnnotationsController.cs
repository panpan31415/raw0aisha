using project.DAL.Rewrittable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project.Controllers
{
    public class AnnotationsController : ApiController
    {
        AnnotationRepository _annotationRepository = new AnnotationRepository();
        public IEnumerable<Annotation> Getannotation()
        {
            return _annotationRepository.GetAllannotation();
        }
    }
}
