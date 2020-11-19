using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public class Seat
    {
        public int Row { get; set; }
        public int SeatNumber { get; set; }
        public bool IsOccupied { get; set; }
        public int TicketPrice { get; set; }
        public Seat(int row, int seatNumber, CinemaRoom room)
        {
            Row = row;
            SeatNumber = seatNumber;
            TicketPrice = SetTicketPrice(room);
        }
        private int SetTicketPrice(CinemaRoom room)
        {
            if ((room.NumberOfSeats >= 50) && (Row <= room.RoomDimentions.NrOfRows / 2))
                return TicketPrice = 12;
            else
                return TicketPrice = 10;
        }
    }
}
