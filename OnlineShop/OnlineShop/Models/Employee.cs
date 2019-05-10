using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? PersonId { get; set; }

        public int? Type { get; set; }

        public int? Sallary { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public virtual Person Person { get; set; }
    }
}