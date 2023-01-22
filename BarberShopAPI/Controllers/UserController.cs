using BarberShopAPI.Models;
using BarberShopAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarberShopAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(string username, string password)
        {
            try
            {
                using (var context = new BarberShopContext()) {
                    UserService us = new UserService();
                    var ret = us.IsUser(username, password);
                    var myToken = Guid.NewGuid();
                  
                    
                    if (ret)
                    {
                        Tokens tk = new Tokens();
                        tk.Token = myToken.ToString();
                        tk.CreationDate = DateTime.Now;
                        var client = context.Client.FirstOrDefault(c => c.Username == username);
                        var barberShop = context.BarberShop.FirstOrDefault(c => c.UserName == username);
                        var barber = context.Barber.FirstOrDefault(c => c.UserName == username);
                        if (client != null) { tk.User = client.IdClient; }
                        else if (barber != null) { tk.User = barber.IdBarber; }
                        else { tk.User = barberShop.IdBarber; }
                        context.Tokens.Add(tk);
                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, myToken);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Credenciales incorrectas");

                    }
                }
            }catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error del servidor");
            }
        }

      
    }
}
