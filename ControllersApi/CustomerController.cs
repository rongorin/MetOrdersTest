using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using OrdersModel.DomainClasses;
using Repository.Interfaces;
using Repository;

namespace MetopeOrdersTest.ControllersApi
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private ISimpleRepository<Customer> _repo;

        public CustomerController(ISimpleRepository<Customer> repo)
        {
            _repo = repo;
        }

        //[Route("api/Customer")] 
        [Route]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            var results = _repo.Get().ToList(); 
             
            if (results.Count > 0)
            {
               ret = Ok(results);
               //return Content(System.Net.HttpStatusCode.BadRequest, "Any object");
            }
            else
            {
                //var myError = new
                //{
                //    Data = "An error just happened",
                //    OtherDetails = "foo bar baz"
                //}; 
                //ret = Content(System.Net.HttpStatusCode.NotFound, myError); ;
                ret = NotFound()  ;  
            }

            return ret;
        }
          [System.Web.Http.HttpGet]  
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret = null;

            Customer cust = new Customer();
            cust = _repo.GetById(id);
            //vm.Products.Clear();
            if (cust != null)
            {
                ret = Ok(cust);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
         [System.Web.Http.HttpPost]   
        public IHttpActionResult Post([FromBody]Customer customer) 
        {
            IHttpActionResult ret = null;

            var resbool = _repo.Add(customer);
             
            if (resbool)
            {
                _repo.Save();
                ret = Created<Customer>(
                        Request.RequestUri +
                        customer.CustomerId.ToString(),
                          customer);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
        [System.Web.Http.HttpPut]  
        public IHttpActionResult Put([FromBody]Customer customer)
        {
            IHttpActionResult ret = null;

            try
            {
                bool resbool = _repo.Update(customer);

                if (resbool)
                {
                    ret = Ok();

                }
                else
                {
                    ret = NotFound();
                }

            }

            catch (Exception e)
            {

                ret = NotFound();
            }

            return ret;
        } 
       [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult ret = null;

            if (id == null)
                return BadRequest();

            bool resbool = _repo.Delete(id);
  
            if (resbool)
            {
                ret = Ok();

            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }
        //public  HttpResponseMessage Post([FromBody]Customer customer)
        //{
        //    IHttpActionResult ret = null;

        //   var response = new HttpResponseMessage();
        //   response.StatusCode = System.Net.HttpStatusCode.BadRequest;

        //   response.Content = new StringContent("12345");

        //   return response;

        //}
    }
}