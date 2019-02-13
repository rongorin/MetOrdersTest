using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MetopeOrdersTest.Models;

namespace MetopeOrdersTest.Controllers
{
    public class OrderAllocationController : Controller
    {
        private MetopeAzureDbEntities db = new MetopeAzureDbEntities();

        // GET: OrderAllocation
        public ActionResult Index()
        {
            var order_Allocation = db.Order_Allocation.Include(o => o.Order_Detail);
            return View(order_Allocation.ToList());
        }

        // GET: OrderAllocation/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Allocation order_Allocation = db.Order_Allocation.Find(id);
            if (order_Allocation == null)
            {
                return HttpNotFound();
            }
            return View(order_Allocation);
        }

        // GET: OrderAllocation/Create
        public ActionResult Create()
        {
            ViewBag.Order_ID = new SelectList(db.Order_Detail, "Order_ID", "Transaction_Type");
            return View();
        }

        // POST: OrderAllocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Allocation_ID,Entity_ID,Order_ID,Portfolio_Code,Target_Quantity,Target_Clean_Amount_TradeCur,Target_Income_Amount_TradeCur,Target_AllIn_Amount_TradeCur,Target_Clean_Amount_BaseCur,Target_Income_Amount_BaseCur,Target_AllIn_Amount_BaseCur,Execution_Quantity,Place_Quantity,Execution_Clean_Amount_TradeCur,Execution_Income_Amount_TradeCur,Execution_AllIn_Amount_TradeCur,Execution_Clean_Amount_BaseCur,Execution_Income_Amount_BaseCur,Execution_AllIn_Amount_BaseCur,Commission_Rate,Commission_Type,Commission_Amount_TradeCur,Commission_Amount_BaseCur,Execution_Gross_Amount_TradeCur,Execution_Gross_Amount_BaseCur,Execution_Net_Amount_TradeCur,Execution_Net_Amount_BaseCur,Buy_Currency_Target_Amount_TradeCur,Sell_Currency_Target_Amount_TradeCur,Buy_Currency_Target_Amount_BaseCur,Sell_Currency_Target_Amount_BaseCur,Buy_Currency_Execution_Amount_TradeCur,Sell_Currency_Execution_Amount_TradeCur,Buy_Currency_Execution_Amount_BaseCur,Sell_Currency_Execution_Amount_BaseCur,Fee_Amount1_TradeCur,Fee_Amount2_TradeCur,Fee_Amount3_TradeCur,Fee_Amount4_TradeCur,Fee_Amount5_TradeCur,Fee_Amount6_TradeCur,Tax_Amount_TradeCur,Fee_Amount1_BaseCur,Fee_Amount2_BaseCur,Fee_Amount3_BaseCur,Fee_Amount4_BaseCur,Fee_Amount5_BaseCur,Fee_Amount6_BaseCur,Tax_Amount_BaseCur,Trade_Base_FX_Rate,Export_Reference,Export_Status,Allocation_Ack_Nack_Status,Operations_Status,Last_Update_Date,Last_Update_User")] Order_Allocation order_Allocation)
        {
            if (ModelState.IsValid)
            {
                db.Order_Allocation.Add(order_Allocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_ID = new SelectList(db.Order_Detail, "Order_ID", "Transaction_Type", order_Allocation.Order_ID);
            return View(order_Allocation);
        }

        // GET: OrderAllocation/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Allocation order_Allocation = db.Order_Allocation.Find(id);
            if (order_Allocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_ID = new SelectList(db.Order_Detail, "Order_ID", "Transaction_Type", order_Allocation.Order_ID);
            return View(order_Allocation);
        }

        // POST: OrderAllocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Allocation_ID,Entity_ID,Order_ID,Portfolio_Code,Target_Quantity,Target_Clean_Amount_TradeCur,Target_Income_Amount_TradeCur,Target_AllIn_Amount_TradeCur,Target_Clean_Amount_BaseCur,Target_Income_Amount_BaseCur,Target_AllIn_Amount_BaseCur,Execution_Quantity,Place_Quantity,Execution_Clean_Amount_TradeCur,Execution_Income_Amount_TradeCur,Execution_AllIn_Amount_TradeCur,Execution_Clean_Amount_BaseCur,Execution_Income_Amount_BaseCur,Execution_AllIn_Amount_BaseCur,Commission_Rate,Commission_Type,Commission_Amount_TradeCur,Commission_Amount_BaseCur,Execution_Gross_Amount_TradeCur,Execution_Gross_Amount_BaseCur,Execution_Net_Amount_TradeCur,Execution_Net_Amount_BaseCur,Buy_Currency_Target_Amount_TradeCur,Sell_Currency_Target_Amount_TradeCur,Buy_Currency_Target_Amount_BaseCur,Sell_Currency_Target_Amount_BaseCur,Buy_Currency_Execution_Amount_TradeCur,Sell_Currency_Execution_Amount_TradeCur,Buy_Currency_Execution_Amount_BaseCur,Sell_Currency_Execution_Amount_BaseCur,Fee_Amount1_TradeCur,Fee_Amount2_TradeCur,Fee_Amount3_TradeCur,Fee_Amount4_TradeCur,Fee_Amount5_TradeCur,Fee_Amount6_TradeCur,Tax_Amount_TradeCur,Fee_Amount1_BaseCur,Fee_Amount2_BaseCur,Fee_Amount3_BaseCur,Fee_Amount4_BaseCur,Fee_Amount5_BaseCur,Fee_Amount6_BaseCur,Tax_Amount_BaseCur,Trade_Base_FX_Rate,Export_Reference,Export_Status,Allocation_Ack_Nack_Status,Operations_Status,Last_Update_Date,Last_Update_User")] Order_Allocation order_Allocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Allocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_ID = new SelectList(db.Order_Detail, "Order_ID", "Transaction_Type", order_Allocation.Order_ID);
            return View(order_Allocation);
        }

        // GET: OrderAllocation/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Allocation order_Allocation = db.Order_Allocation.Find(id);
            if (order_Allocation == null)
            {
                return HttpNotFound();
            }
            return View(order_Allocation);
        }

        // POST: OrderAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Order_Allocation order_Allocation = db.Order_Allocation.Find(id);
            db.Order_Allocation.Remove(order_Allocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
