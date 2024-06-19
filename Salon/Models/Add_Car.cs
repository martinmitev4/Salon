using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Add_Car
    {
        public int CarId { get; set; }
        public int Car_dealershipId { get; set; }
        public Car Selected_Car { get; set; }
        public List<Car> Cars { get; set; }
    }
}