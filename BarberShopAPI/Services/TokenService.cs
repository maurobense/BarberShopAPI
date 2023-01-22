using BarberShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarberShopAPI.Services
{
    public class TokenService : ITokenService
    {
        public bool IsValidToken(string token)
        {
            var context = new BarberShopContext();
            var cred = token.Split(new[] { ':' },2);
            return context.Tokens.Where(tk => tk.User == Convert.ToInt32(cred[0]) && tk.Token == cred[1]).Count() > 0;
        }
    }
}