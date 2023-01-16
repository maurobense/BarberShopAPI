using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarberShopAPI.Models.Dto
{
    public class TurnDto
    {
        public int IdTurn { get; set; }
        public DateTime Date { get; set; }
        public int? Active { get; set; }
        public int? IdBarber { get; set; }
        public int? Reserved { get; set; }
        public DateTime? To { get; set; }
    }
}