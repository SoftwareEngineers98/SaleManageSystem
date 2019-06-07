using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModel;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace OnlineShop.Controllers
{
    public class BasketController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Final()
        {
            return View();
        }
        public ActionResult Buy(int id)
        {
            BasketViewModel baskets = new BasketViewModel();
            if (Session["ShoppingBasketItem"] == null)
            {
                List<ProductInBasket> basket = new List<ProductInBasket>();
                Product product = baskets.FindById(id);
                ProductInBasket bb = new ProductInBasket();
                bb.product = product;

                //if (bb.product.Count > 1)
                //{
                    bb.ProductCount = 1;
                    basket.Add(bb);
                    //Product pro = new Product();
                    //var Product = from p in db.Product
                    //              where p.Id == bb.product.Id
                    //              select p;
                    //product.Count--;
                   
                    //db.SaveChanges();

                    Session["ShoppingBasketItem"] = basket;
                    //return RedirectToAction("Index");
                //}
                //else
                //{
                //    ViewBag.error = "از این محصول به تعداد کافی موجود نیست!!!";
                //    return RedirectToAction("Index", "MainPage");
                //}
            }
            else
            {

                List<ProductInBasket> basket = new List<ProductInBasket>();
                Product product = baskets.FindById(id);
                ProductInBasket bb = new ProductInBasket();
                bb.product = product;

                //if (bb.product.Count > 1)
                //{
                    bb.ProductCount = 1;
                    basket.Add(bb);
                //}
                //else
                //{
                //    ViewBag.error = "از این محصول به تعداد کافی موجود نیست!!!";
                //    return RedirectToAction("Index", "MainPage");
                //}
                Session["ShoppingBasketItem"] = basket;

            }
            return RedirectToAction("Index");
        }
        public ActionResult SubCount(int id)
        {
            if (Session["ShoppingBasketItem"] != null)
            {
                List<ProductInBasket> productsInBasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;

                int idd = productsInBasket.FindIndex(p => p.product.Id == id);

                ProductInBasket item = productsInBasket[idd];
                if (item.ProductCount == 1)
                {
                    productsInBasket.RemoveAt(idd);
                }
                else
                {
                    item.ProductCount--;
                    productsInBasket[idd] = item;
                }
                Session["ShoppingBasketItem"] = productsInBasket;
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddCount(int id)
        {
            if (Session["ShoppingBasketItem"] != null)
            {
                List<ProductInBasket> productsInBasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;

                int idd = productsInBasket.FindIndex(p => p.product.Id == id);

                ProductInBasket item = productsInBasket[idd];
                item.ProductCount++;
                productsInBasket[idd] = item;
                Session["ShoppingBasketItem"] = productsInBasket;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (Session["ShoppingBasketItem"] != null)
            {
                List<ProductInBasket> productsInBasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;
                int index = productsInBasket.FindIndex(p => p.product.Id == id);
                productsInBasket.RemoveAt(index);
                Session["ShoppingBasketItem"] = productsInBasket;
            }
            return RedirectToAction("Index");
        }

        
    }
}