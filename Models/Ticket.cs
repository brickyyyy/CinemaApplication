using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public class Ticket
    {
        public int Price {get;set;}

        public Ticket(Seat seat)
        {
            Price = seat.TicketPrice;
        }
    }
}
