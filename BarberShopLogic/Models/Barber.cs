using System;
using System.Collections.Generic;

#nullable disable

namespace BarberShopLogic.Models
{
    public partial class Barber
    {
        public Barber()
        {
            BarberBarberShops = new HashSet<BarberBarberShop>();
            TurnBarbers = new HashSet<TurnBarber>();
        }

        public int IdBarber { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Cel { get; set; }
        public int? IdBarberShop { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual BarberShop IdBarberShopNavigation { get; set; }
        public virtual ICollection<BarberBarberShop> BarberBarberShops { get; set; }
        public virtual ICollection<TurnBarber> TurnBarbers { get; set; }
    }
}
