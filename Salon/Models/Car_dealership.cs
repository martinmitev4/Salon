using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Car_dealership
    {
        [Key]
        public int Car_dealershipId { get; set; }
        public string Name { get; set; }
        public string City { get; set;}
        public virtual ICollection<Car> Cars { get; set; }
        public Car_dealership()
        {
            Cars = new List<Car>();
        }
       
    }
}