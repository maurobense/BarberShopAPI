using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberShopAPI.Models
{
    public partial class Tokens
    {
        public int IdToken { get; set; }
        public int User { get; set; }
        public string Token { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
