using System;
using System.Collections.Generic;

#nullable disable

namespace BarberShopLogic.Models
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
