using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
{
    public partial class Client
    {
        public Client()
        {
            Booking = new HashSet<Booking>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Cel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
