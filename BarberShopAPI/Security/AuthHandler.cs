using BarberShopAPI.Services;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BarberShopAPI.Security
{
    public class AuthHandler : AuthorizeAttribute
    {

        protected override bool IsAuthorized(HttpActionContext actionContext) {
            return true;
        }
    }
}