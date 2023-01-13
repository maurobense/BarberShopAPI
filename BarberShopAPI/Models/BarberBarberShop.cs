using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
{
    public partial class BarberBarberShop
    {
        public int IdBarber { get; set; }
        public int IdBarberShop { get; set; }

        public virtual Barber IdBarberNavigation { get; set; }
        public virtual BarberShop IdBarberShopNavigation { get; set; }
    }
}
