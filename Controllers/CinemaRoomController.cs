using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApplication.Models;

namespace CinemaApplication.Controllers
{
    public class CinemaRoomController 
    {
        private CinemaRoom cinemaRoom { get; set; }
        public CinemaRoomController(int rows, int seatsPerRow)
        {
            cinemaRoom = CreateCinemaRoom(rows, seatsPerRow);
            GenerateEmptySeats();
        }

        private CinemaRoom CreateCinemaRoom(int rows, int seatsPerRow)
        {
            if (rows <= 0 || seatsPerRow <= 0)
            {
                Console.WriteLine("Rows and seats must be positive numbers!");
                throw new NotImplementedException();
            }
            else
            {
                return new CinemaRoom(rows, seatsPerRow);
            }  
        }
        private void GenerateEmptySeats()
        {
            int i = 1;
            
            while (i <= cinemaRoom.RoomDimentions.NrOfRows)
            {
                int j = 1;
                while (j <=cinemaRoom.RoomDimentions.SeatsPerRow)
                {
                    var seat = new Seat(i, j, cinemaRoom);
                    seat.IsOccupied = false;
                    cinemaRoom.Seats.Add(seat);
                    j++;
                }
                i++; 
            }
        }
        public void BuyTicket(Seat seat)
        {
            if (!seat.IsOccupied)
            {
               cinemaRoom.Seats.Where(s => s.Row == seat.Row && s.SeatNumber == seat.SeatNumber).ToList().
               ForEach(s => s.IsOccupied = true);
            }
            else
            {
                Console.WriteLine("This seat is unavailable, please select another seat!");
            }
           
        }
        public void PrintCinemaRoom()
        {
            //generate sequence of seats
            var seats = Enumerable.Range(1, cinemaRoom.RoomDimentions.SeatsPerRow).ToList();
            var seatString = String.Join(" ", seats);
            Console.Write("A - Available seat\n");
            Console.Write("R - Reserved seat\n\n");
            Console.Write(String.Format("Seats {0}\t", seatString.PadRight(6)));
            Console.WriteLine("------------------------\n");
            //Console.Write(String.Format("{0}\tA\tB\tC\tD\tE\tF\n", " ".PadRight(6)));
            for (int i = 1; i <= cinemaRoom.RoomDimentions.NrOfRows; i++)
            {
                Console.Write(String.Format("Row {0}\t", (i).ToString().PadRight(2)));

                for (int j = 1; j <= cinemaRoom.RoomDimentions.SeatsPerRow; j++)
                {

                    if (!IsSelectedSeatOccupied(i, j))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(String.Format("{0}\t", "A")); ;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0}\t", "R")); ;
                    }
                    ResetColors();
                }
                ResetColors();
                Console.WriteLine();
            }

        }

        private static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool IsSelectedSeatOccupied(int rowNumber, int seatNumber)
        {
            var seat= cinemaRoom.Seats.FirstOrDefault(s => s.Row == rowNumber && s.SeatNumber == seatNumber);
            return seat.IsOccupied;
        }
        public void ShowStatistics()
        {
            Console.WriteLine("Rows and seats must be positive numbers!");
        }
    }
}
