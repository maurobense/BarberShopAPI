using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
{
    public partial class Barber
    {
        public Barber()
        {
            BarberBarberShop = new HashSet<BarberBarberShop>();
        }

        public int IdBarber { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Cel { get; set; }
        public int? IdBarberShop { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

        public virtual BarberShop IdBarberShopNavigation { get; set; }
        public virtual ICollection<BarberBarberShop> BarberBarberShop { get; set; }
        public virtual ICollection<TurnBarber> TurnBarber { get; set; }
    }
}
