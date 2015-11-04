using project.DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project.Controllers
{
    public class HistorysController : ApiController
    {
        HistoryRepository _hisRepository = new HistoryRepository();
        public IEnumerable<History> Get()
        {
            return _hisRepository.GetAll();
        }
    }
}
