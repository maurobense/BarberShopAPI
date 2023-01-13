using BarberShopLogic.Models;
using System;

namespace BarberShopLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BarberShopContext())
            {
                foreach(var turn in context.Bookings)
                {
                    Console.WriteLine(turn);
                }
            }
        }
    }
}
