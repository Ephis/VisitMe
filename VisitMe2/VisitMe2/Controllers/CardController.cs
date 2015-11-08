using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VisitMe2.Models;

namespace VisitMe2.Controllers
{
    [RoutePrefix("api/Cards")]
    public class CardController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            VistmeContext db = new VistmeContext();
            return Ok(db.cards);
        }
    }
}
