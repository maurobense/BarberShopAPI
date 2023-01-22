using BarberShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarberShopAPI.Services
{
    public class UserService : IUserService
    {
        public bool IsUser(string username, string password)
        {
            var context = new BarberShopContext();
            return context.BarberShop.Where(bs => bs.UserName == username && bs.Password == password).Count() > 0 || context.Barber.Where(bs => bs.UserName == username && bs.Password == password).Count() > 0 || context.Client.Where(bs => bs.Username == username && bs.Password == password).Count() > 0;
        }
    }
}