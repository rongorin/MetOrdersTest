using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrdersModel.DataLayer;
using OrdersModel.DomainClasses;
using Repository.Interfaces;
using Repository;

namespace MetopeOrdersTest.Controllers
{
    public class CustomerController : Controller
    { 

        private ISimpleRepository<Customer> _repo;

        public CustomerController(ISimpleRepository<Customer> repo)
        {
          _repo = repo;
        }

        //now using DI IoC
        //public CustomerController()  
        //        : this(new SimpleCustomerRepository())
        //{ }



        // GET: Customer
        public ActionResult Index()
        {
           return View(_repo.Get().ToList());
       
        }

        // GET: Customer
        public ActionResult IndexAngularHome()
        {
            return View(_repo.Get().ToList());
       
        }

        public ActionResult IndexKeepbup()
        {
            return View(_repo.Get().ToList());
        }

        //// GET: Customer/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        //// GET: Customer/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Customer/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Customers.Add(customer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(customer);
        //}

        //// GET: Customer/Edit/5
        public ActionResult Edit(int  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _repo.GetById (id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //// POST: Customer/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(customer);
        //}

        //// GET: Customer/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        //// POST: Customer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    db.Customers.Remove(customer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
