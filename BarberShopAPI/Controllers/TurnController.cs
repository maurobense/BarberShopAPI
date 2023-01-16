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
        [HttpGet]
        public HttpResponseMessage Get(int idBarber, DateTime day)
        {
            try
            {
                using(var context = new BarberShopContext())
                {
                    var turns = context.TurnBarber.Where(t => t.IdBarber == idBarber && t.Date.Year == day.Year && t.Date.Day == day.Day && t.Date.Month == day.Month && t.Reserved == 0 && t.Active == 1).ToList();
                    var myTurns = new List<TurnDto>();
                    if (turns.Count > 0) {
                        foreach (var t in turns)
                        {
                            myTurns.Add(new TurnDto
                            {
                                IdTurn = t.IdTurn,
                                IdBarber = t.IdBarber,
                                Active = t.Active,
                                Reserved = t.Reserved,
                                Date = t.Date,
                                To = t.To

                            });
                        }
                        var turnsJson = JsonSerializer.Serialize(myTurns);
                        return Request.CreateResponse(HttpStatusCode.OK, turnsJson);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent, "Este barbero no tiene turnos disponibles en esta fecha");
                    }
                }
                
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }
    }
}
