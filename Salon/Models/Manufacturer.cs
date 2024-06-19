using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        [Display(Name = "Manufacturer")]
        public string Name { get; set; }
        public string City { get; set; }
    }
}