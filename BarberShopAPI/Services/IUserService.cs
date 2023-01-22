using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopAPI.Services
{
    public interface IUserService
    {
       bool IsUser(string email, string pass);
    }
}
