using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("api/status")]
        public IHttpActionResult Status()
        {
            return this.Ok("Im fine");
        }
    }
}