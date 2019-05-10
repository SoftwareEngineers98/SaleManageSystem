using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            basketdetail = new HashSet<OrderDetail>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime  OrderDate { get; set; }
        public bool IsFinalized { get; set; }

        public Customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<OrderDetail> basketdetail { get; set; }
    }
}