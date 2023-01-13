using System;
using System.Collections.Generic;

#nullable disable

namespace BarberShopLogic.Models
{
    public partial class BarberShop
    {
        public BarberShop()
        {
            BarberBarberShops = new HashSet<BarberBarberShop>();
            Barbers = new HashSet<Barber>();
        }

        public int IdBarber { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int? Cel { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BarberBarberShop> BarberBarberShops { get; set; }
        public virtual ICollection<Barber> Barbers { get; set; }
    }
}
