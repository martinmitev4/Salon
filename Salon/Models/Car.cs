using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        
        public int ManufacturerId { get; set; }
        [Display(Name = "Model")]
        [Required]
        public string Model_Name { get; set; }
        [Display(Name = "Year")]
        public string God { get; set; }
        public string Image { get; set; }
        public string Power { get; set; }
        [Display(Name = "Manufacturer")]
        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Fuel Type")]
        public string Fuel_type { get; set; }

        public string Gearbox { get; set; }
        [Display(Name = "Horse Power")]
        public string Horse_Power { get; set; }

        public virtual ICollection<Car_dealership> Car_d { get; set; }
        public Car()
        {
            Car_d = new List<Car_dealership>();
        }

    }
}