using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers
{
    public class ArticleDataController : ApiController
    {
        // GET: api/ArticleData
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ArticleData/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ArticleData
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ArticleData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ArticleData/5
        public void Delete(int id)
        {
        }
    }
}
