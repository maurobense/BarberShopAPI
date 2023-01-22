using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopAPI.Services
{
    public interface ITokenService
    {
        bool IsValidToken(string token);
    }
}
