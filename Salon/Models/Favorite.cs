using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int PriceId { get; set; }
        public string Image { get; set; }
        public Price FavCars { get; set; }
    }
}