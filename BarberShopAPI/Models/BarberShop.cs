using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
{
    public partial class BarberShop
    {
        public BarberShop()
        {
            Barber = new HashSet<Barber>();
            BarberBarberShop = new HashSet<BarberBarberShop>();
        }

        public int IdBarber { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int? Cel { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Barber> Barber { get; set; }
        public virtual ICollection<BarberBarberShop> BarberBarberShop { get; set; }
    }
}
