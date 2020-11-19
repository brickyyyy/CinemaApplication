using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public class CinemaRoom
    {
        public int NumberOfSeats { get; set; }
        public List<Seat> Seats { get; set; }
        public SizeOfRoom RoomDimentions { get; set; }
        public double PercentageOccupied { get; set; }
        public int CurrentIncome { get; set; }
        public int PotentialIncome { get; set; }
        public CinemaRoom(int rows, int seatsPerRow)
        {
            RoomDimentions = new SizeOfRoom(rows, seatsPerRow);
            NumberOfSeats = rows * seatsPerRow;
            Seats = new List<Seat>();
            PercentageOccupied = CalculateOccupiedPercent(); 
            CurrentIncome = CalculateIncome();
            PotentialIncome = CalculatePotentialIncome();
        }

        private double CalculateOccupiedPercent()
        {
            var OccupiedSeats = Seats.Where(s => s.IsOccupied == true).ToList();
            return (OccupiedSeats.Count / NumberOfSeats) * 100;
        }

        private int CalculateIncome()
        {
            var OccupiedSeats = Seats.Where(s => s.IsOccupied == true).ToList();
            return OccupiedSeats.Sum(x => x.TicketPrice);
        }
        private int CalculatePotentialIncome()
        {
            if ((NumberOfSeats > 50) && (NumberOfSeats % 2 != 1))
            {
                return (((NumberOfSeats / 2) * 12) + ((NumberOfSeats / 2) * 10));
            }
            if ((NumberOfSeats > 50) && (NumberOfSeats % 2 == 1))
            {
                return (int)((Utilities.RoundDown(NumberOfSeats / 2) * 12) + (Utilities.RoundUp(NumberOfSeats / 2) * 10));
            }
            else if(NumberOfSeats==0)
            {
                //TODO: catch exception
                throw new IndexOutOfRangeException();
            }
            else
            {
                return (NumberOfSeats * 10);
            }
        }
    }
}
