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
    public class TurnController : ApiController
    {
        [HttpPost]

        public HttpResponseMessage Post(DateTime dateFrom, DateTime dateTo,int idBarber)
        {
            try
            {
                using(var context = new BarberShopContext())
                {
                    var barberTurns = context.TurnBarber.Where(t => t.IdBarber == idBarber &&(dateFrom <= t.Date && dateTo >= t.To
                    || (dateFrom >= t.Date && dateTo <= t.To)
                    || (dateFrom <= t.Date) && dateTo <= t.To && dateTo > t.Date
                    || dateFrom >= t.Date && dateFrom < t.To)).ToList();
                    
                        if(barberTurns.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest,"Ya existe un turno en ese horario");
                        }
                    
                    TurnBarber turn = new TurnBarber();
                    turn.Date = dateFrom;
                    turn.To = dateTo;
                    turn.IdBarber = idBarber;
                    turn.Reserved = 0;
                    turn.Active = 1;
                    context.TurnBarber.Add(turn);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,"Turno creado con exito : "+ turn.Date);
                }

            }catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}
