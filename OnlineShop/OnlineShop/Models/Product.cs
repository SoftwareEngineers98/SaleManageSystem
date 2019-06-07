using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Sale = new HashSet<Sale>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "نام محصول")]
        public string Name { get; set; }
        [Display(Name = "دسته بندی")]
        public ProductType Type { get; set; }
        [Display(Name = "قیمت")]
        public int Cost { get; set; }

        [StringLength(50)]
        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [StringLength(5000)]
        [Display(Name = "شرح محصول ")]
        public string Description { get; set; }
        [Display(Name = "تعداد")]
        public int Count { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
    }

    public enum ProductType
    {
        [Display(Name = "کامپیوتر  ")]
        PC = 1,
        [Display(Name = "موبایل ")]
        Mobile = 2,
        [Display(Name = "لوازم جانبی موبایل")]
        Accessory = 3,
        [Display(Name = "تلوزیون")]
        TV = 4,
    }
}