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
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            var results = _repo.Get().ToList();
             
            //vm.Products.Clear();
            if (results.Count > 0)
            {
               ret = Ok(results);
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
    }
}