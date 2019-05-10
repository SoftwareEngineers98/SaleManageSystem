using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDetail()
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BasketId { get; set; }
        public int Count { get; set; }
        public Product product { get; set; }
        public Order basket { get; set; }
    }
}