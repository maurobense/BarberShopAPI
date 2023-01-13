using System;
using System.Collections.Generic;

#nullable disable

namespace BarberShopLogic.Models
{
    public partial class Booking
    {
        public int IdBooking { get; set; }
        public int IdClient { get; set; }
        public int IdTurn { get; set; }
        public string Description { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual TurnBarber IdTurnNavigation { get; set; }
    }
}
