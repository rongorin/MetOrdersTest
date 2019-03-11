using OrdersModel.DomainClasses;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MetopeOrdersTest.Controllers
{
    public class CustomerApiController : ApiController
    {
        private ISimpleRepository<Customer> _repo;
        
        public CustomerApiController(ISimpleRepository<Customer> repo)
        {
            _repo = repo;
        }
        // GET: api/CustomerApi
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            var results = _repo.Get().ToList();
           
            results.Clear();
            if (results.Count > 0)
            {
               // ret = Ok(results);
                return Content(HttpStatusCode.BadRequest, "Any object");
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
        // GET: api/CustomerApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CustomerApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerApi/5
        public void Delete(int id)
        {
        }
    }
}
