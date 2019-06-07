using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModel
{
    public class BasketViewModel
    {
        private ShopContext db = new ShopContext();
        private List<Product> products;
        public BasketViewModel()
        {
        }
        public List<Product> FindProducts()
        {
            var ProductList = (from a in db.Product select a).ToList();
            return ProductList;
        }
        public Product FindById(int id)
        {
            var product = db.Product.Find(id);
            return product;
        }
    }
}