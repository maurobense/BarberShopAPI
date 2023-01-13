using System;
using System.Collections.Generic;

#nullable disable

namespace BarberShopLogic.Models
{
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Cel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
