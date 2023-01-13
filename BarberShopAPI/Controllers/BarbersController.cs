using BarberShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using BarberShopAPI.Models.Dto;

namespace BarberShopAPI.Controllers
{
    public class BarbersController : ApiController
    {
        [HttpGet]
        public string Get(long idBarberShop)
        {
            try 
            {
                using (var context = new BarberShopContext())
                {
                    var query = context.Barber.Where(b => b.IdBarberShop == idBarberShop).ToList();
                    var barbers = new List<BarberDto>();
                    var barbersJson = "";
                    var turns = new List<int>();
                    foreach(var b in query)
                    {
                        var queryTurns = context.TurnBarber.Where(t => t.IdBarber == b.IdBarber).ToList();
                        foreach(var t in queryTurns)
                        {
                            turns.Add(t.IdTurn);
                        }
                        barbers.Add(new BarberDto { 
                            IdBarber = b.IdBarber,
                            Nickname = b.Nickname,
                            Name = b.Name,
                            LastName = b.LastName,
                            Cel = b.Cel,
                            IdBarberShop = b.IdBarberShop,
                            Picture = b.Picture,
                            TurnBarber = turns
                        });
                       
                    }
                    barbersJson = JsonSerializer.Serialize(barbers);
                    return barbersJson;
                }
            }catch(Exception e)
            {
                return "Error";
            }
        }
    }
}
