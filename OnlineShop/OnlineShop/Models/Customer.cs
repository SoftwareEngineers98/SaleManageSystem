using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoice = new HashSet<Invoice>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PersonId { get; set; }
        [Display(Name = "نوع کاربری")]

        public CustomerType? Type { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
    public enum CustomerType
    {
        [Display(Name = "مشتری عالی")]
        BestCustomer = 1,
        [Display(Name = "مشتری خوب ")]
        GoodCustomer = 2,
        [Display(Name = "مشتری بدحساب")]
        BadCustomer = 3,

    }
}