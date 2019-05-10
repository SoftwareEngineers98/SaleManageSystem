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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0 ریال}")]
        public int ProductCost { get; set; }
        public int ProductCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0 ریال}")]
        public int TotalCost { get; set; }
    }
}