using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarberShopAPI.Models.Dto
{
    public class BarberDto
    {
        public int IdBarber { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Cel { get; set; }
        public int? IdBarberShop { get; set; }
        public string Picture { get; set; }

        public List<int> TurnBarber { get; set; }
    }
}