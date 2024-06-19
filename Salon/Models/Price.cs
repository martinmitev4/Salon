using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Price
    {
        public int PriceId { get; set; }
        public int FavoriteId { get; set; }
        public int Car_dealershipId { get; set; }
        public int CarId { get; set; }
        public string price { get; set; }
        public Car_dealership Car_Dealership { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Price()
        {
            Cars = new List<Car>();
        }
    }
}