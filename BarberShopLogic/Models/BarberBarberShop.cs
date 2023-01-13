using System;
using System.Collections.Generic;

#nullable disable

namespace BarberShopLogic.Models
{
    public partial class BarberBarberShop
    {
        public int IdBarber { get; set; }
        public int IdBarberShop { get; set; }

        public virtual Barber IdBarberNavigation { get; set; }
        public virtual BarberShop IdBarberShopNavigation { get; set; }
    }
}
