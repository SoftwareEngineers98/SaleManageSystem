using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModel
{
    public class ProductInBasket
    {
        public ProductInBasket()
        {

        }
        public Product product { get; set; }
        public int ProductCount { get; set; }
    }
}