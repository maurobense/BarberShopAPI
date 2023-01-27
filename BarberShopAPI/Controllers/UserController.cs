using BarberShopAPI.Models;
using BarberShopAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BarberShopAPI.Security;
using BarberShopAPI.Models.Dto;
using Newtonsoft.Json;


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
                    var token = "";
                  
                    
                    if (ret)
                    {
                        var client = context.Client.FirstOrDefault(c => c.Username == username);
                        var barberShop = context.BarberShop.FirstOrDefault(c => c.UserName == username);
                        var barber = context.Barber.FirstOrDefault(c => c.UserName == username);
                        if (barber != null) {
                            token = TokenHandler.GenerateToken(JsonConvert.SerializeObject(new UserDto
                            {
                                IdUser = barber.IdBarber,
                                UserName = barber.UserName
                            }));
                        }
                        else {
                            token = TokenHandler.GenerateToken(JsonConvert.SerializeObject(new UserDto
                            {
                                IdUser = barberShop.IdBarber,
                                UserName = barberShop.UserName
                            }));

                        }
                        var decodedJWT = TokenHandler.DecodeToken(token);


                        return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<UserDto>(decodedJWT));
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
