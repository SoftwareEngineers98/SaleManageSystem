using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers
{
    public class InvoicesController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoice = db.Invoice.Include(i => i.Customer);
            return View(invoice.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Image");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,Code,Date,Status")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoice.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Image", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Image", invoice.CustomerId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,Code,Date,Status")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Image", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoice.Find(id);
            db.Invoice.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Finalize()
        {
            List<ProductInBasket> productsInBasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;
            Invoice invoice = new Invoice();
            invoice.Date = DateTime.Now;
            invoice.CustomerId = 1;
            invoice.Code = NewNumber().ToString();
            invoice.Status = 0;
            db.Invoice.Add(invoice);
            db.SaveChanges();
            foreach (var item in productsInBasket)
            {

                Sale sale = new Sale();
                sale.InvoiceId = invoice.Id;
                sale.Count = item.ProductCount;
                sale.Fee = item.ProductCount * item.product.Cost;
                sale.ProductId = item.product.Id;
                db.Sale.Add(sale);
                db.SaveChanges();
            }
            ViewBag.data = invoice.Code;
            Session["ShoppingBasketItem"] = null;
            return View(invoice);
        }
        public Random a = new Random();

        public List<int> randomList = new List<int>();
        int MyNumber = 0;
        private int NewNumber()
        {
            bool aa = false;
            int MyNumber = 0;
            while (!aa)
            {
                MyNumber = a.Next(1000, 999999999);
                if (!randomList.Contains(MyNumber))
                {
                    randomList.Add(MyNumber);
                    aa = true;
                }

            }
            return MyNumber;

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
