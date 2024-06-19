using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon.Models
{
    public class Addrole
    {
        public string Email { get; set; }
        public string Selectedroles { get; set; }

        public List<string> roles { get; set; }

        public Addrole()
        {
            roles = new List<string>();

        }
    }
}