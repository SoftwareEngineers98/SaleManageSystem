using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModel;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Controllers
{
    public class BasketController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Basket
        public ActionResult Index()
        {
            List<BasketViewModel> basketcontent = new List<BasketViewModel>();
            if (Session["ShoppingBasketItem"]!= null)
            {
                List<ProductInBasket> productsInBasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;
                var dbProducts = db.Product.ToList();

                basketcontent = (from pr in dbProducts
                                join pib in productsInBasket
                                    on pr.Id equals pib.ProductId
                                select new BasketViewModel
                                {
                                    ProductId = pr.Id,
                                    ProductName = pr.Name,
                                    ProductCost = pr.Cost,
                                    ProductCount = pib.ProductCount,
                                    TotalCost = pr.Cost * pib.ProductCount
                                }).ToList();
                return View(basketcontent);
            }

            return View(basketcontent);
        }
        public ActionResult SubCount(int id)
        {
            if (Session["ShoppingBasketItem"] != null)
            {
                List<ProductInBasket> productsInBasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;

                int idd = productsInBasket.FindIndex(p => p.ProductId == id);

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

                int idd = productsInBasket.FindIndex(p => p.ProductId == id);

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
                int index = productsInBasket.FindIndex(p => p.ProductId == id);
                productsInBasket.RemoveAt(index);
                Session["ShoppingBasketItem"] = productsInBasket;
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Finalize()
        {
            List<BasketViewModel> basketcontents = new List<BasketViewModel>();

            if (Session["ShoppingBasketItem"] != null)
            {
                List<ProductInBasket> productsInbasket = Session["ShoppingBasketItem"] as List<ProductInBasket>;

                var dbProducts = db.Product.ToList();

                basketcontents = (from pr in dbProducts
                                join pir in productsInbasket on pr.Id equals pir.ProductId
                                select new BasketViewModel
                                {
                                    ProductId = pr.Id,
                                    ProductName = pr.Name,
                                    ProductCost = pr.Cost,
                                    ProductCount = pir.ProductCount,
                                    TotalCost = pr.Cost * pir.ProductCount
                                }).ToList();

                var userId = User.Identity.GetUserId();
                Order order = new Order()
                {
                    CustomerId = Convert.ToUInt16(userId),
                    OrderDate = DateTime.Now,
                    IsFinalized = false
                };

                db.Order.Add(order);

                foreach (BasketViewModel item in basketcontents)
                {
                    db.OrderDetail.Add(new OrderDetail()
                    {
                        Id = order.Id,
                        ProductId = item.ProductId,
                        Count = item.ProductCount
                    });
                }
                db.SaveChanges();

                Session["ShoppingBasketItem"] = null;
            }

            return RedirectToAction("Orders");
        }
        //[Authorize]
        //public ActionResult Orders()
        //{
        //    var userId = User.Identity.GetUserId();

        //    var userOrders = (from o in db.Order
        //                      where o.CustomerId == userId
        //                      select new OrdersViewModel()
        //                      {
        //                          OrderID = o.OrderID,
        //                          OrderDate = o.OrderDate,
        //                          IsFinalized = o.IsFinalized,
        //                          OrderTotal = (from od in db.OrderDetails
        //                                        join p in db.Products on od.ProductID equals p.ProductID
        //                                        where od.OrderID == o.OrderID
        //                                        select p.ProductPrice * od.OrderedCount).Sum(),
        //                          OrderDetails = o.OrderDetails
        //                      }).ToList();

        //    return View(userOrders);
        //}
    }
}