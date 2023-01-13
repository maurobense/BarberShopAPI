﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
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
