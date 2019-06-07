using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class MainPageController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: MainPage
        public ActionResult Index(string searchitem)
        {
          
            var product = from p in db.Product select p;
            if (!String.IsNullOrEmpty(searchitem))
            {
                product = product.Where(x => x.Name.Contains(searchitem));
                 //count = product.Where(x => x.Name.Contains(searchitem)).Count();
            }
           
            //var a = product.Count();
            //ViewBag.tedad = count;
            return View(product);
        }
        public ActionResult Index2(int id)
        {
           
            var product = from n in db.Product
                          where (int)n.Type == id
                          select n;
            ViewBag.product = product.ToList();
            return View("Index");
        }
       public ActionResult ContactUs()
        {
            return View();
        }
    }
}