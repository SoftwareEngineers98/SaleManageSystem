using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Controllers;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagePerson()
        {
            return RedirectToAction("index","People");
        }
        public ActionResult ManageCuctomer()
        {
            
            return RedirectToAction("index", "Customers");

        }
        public ActionResult ManageProduct()
        {
            return RedirectToAction("index", "Products");
        }
    }
}