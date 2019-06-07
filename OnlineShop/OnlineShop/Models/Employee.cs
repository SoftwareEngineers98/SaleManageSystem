using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PersonId { get; set; }
        [Display(Name = "نوع کاربری")]
        public EmployeeType Type { get; set; }
        [Display(Name = "حقوق")]
        public int? Sallary { get; set; }
        [Display(Name = "تصویر")]
        [StringLength(50)]
        public string Image { get; set; }

        public virtual Person Person { get; set; }
    }
    public enum EmployeeType
    {
        [Display(Name = "مدیر")]
        Admin = 1,
        [Display(Name = "حسابدار")]
        Accountant = 2,
        [Display(Name = " رئیس فروشگاه")]
        MasterOfShop = 3,
        [Display(Name = " پشتیبان فروش")]
        Supporter = 3,
    }

}