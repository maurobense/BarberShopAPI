using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
{
    public partial class TurnBarber
    {
        public int IdTurn { get; set; }
        public DateTime Date { get; set; }
        public int? Active { get; set; }
        public int? IdBarber { get; set; }
        public int? Reserved { get; set; }
        public DateTime? To { get; set; }

        public virtual Barber IdBarberNavigation { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
