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
        public CinemaRoomController()
        {
                
        }
        private CinemaRoom CreateCinemaRoom(int rows, int seatsPerRow)
        {
            //if (rows > 0 || seatsPerRow > 0) -->checked in startup class
            return new CinemaRoom(rows, seatsPerRow);
        }
        public List<int> StartUpCinemaRoom()
        {
            Console.WriteLine("To create a Cinema room, enter number of Rows and Seats.");
            Console.WriteLine("Please enter numbers, comma-separated: ");
            return Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToList();
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

        public void ChooseAction(string output)
        {
            switch(output)
            {
                case "b":
                    var seatLocation = AskForRowAndSeat();
                    BuyTicket(new Seat(seatLocation[0], seatLocation[1],cinemaRoom));
                    break;
                case "c":
                    PrintCinemaRoom();
                    break;
                case "s":
                    ShowStatistics();
                    break;
                default:
                    Console.WriteLine("Please write another letter!");
                    break;
            }
        }
        private List<int> AskForRowAndSeat()
        {
            Console.WriteLine("Please write row and seat numbers, comma-separated: ");
            return Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToList();
        }
        private void BuyTicket(Seat seat)
        {
            if (!seat.IsOccupied && cinemaRoom.Seats.Any(s => s.Row == seat.Row && s.SeatNumber == seat.SeatNumber))
            {
               cinemaRoom.Seats.Where(s => s.Row == seat.Row && s.SeatNumber == seat.SeatNumber).ToList().
               ForEach(s => s.IsOccupied = true);
                UpdateStatistics(seat);
                var args = new string[] { seat.Row.ToString(), seat.SeatNumber.ToString(), seat.TicketPrice.ToString() };
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You just bough seat number: {0} on row number {1} for {2}$!", args);
                ResetColors();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This seat is unavailable or doesn't exist, please select another seat!");
                ResetColors();
            }
           
        }

        private void UpdateStatistics(Seat seat)
        {
            cinemaRoom.CurrentIncome += seat.TicketPrice;
            cinemaRoom.NumberOfSoldTickets = cinemaRoom.Seats.Where(s => s.IsOccupied == true).ToList().Count;
            cinemaRoom.PercentageOccupied = cinemaRoom.CalculateOccupiedPercent();
        }

        private void PrintCinemaRoom()
        {
            //generate sequence of seats
            var seats = Enumerable.Range(1, cinemaRoom.RoomDimentions.SeatsPerRow).ToList();
            var seatString = String.Join(" ", seats);
            Console.Write("A - Available seat\n");
            Console.Write("R - Reserved seat\n\n");
            Console.Write(String.Format("Seats {0}\t", seatString));
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
                        Console.Write(String.Format("{0}\t", "A")); 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0}\t", "R"));
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
        private void ShowStatistics()
        {
            Console.WriteLine("Current income is: {0}.", cinemaRoom.CurrentIncome.ToString());
            Console.WriteLine("Number of sold tickets is: {0}.", cinemaRoom.NumberOfSoldTickets.ToString());
            Console.WriteLine("Potential income is: {0}.", cinemaRoom.PotentialIncome.ToString());
            Console.WriteLine("Percentage occupied is: {0}%.", cinemaRoom.PercentageOccupied.ToString());
        }
    }
}
