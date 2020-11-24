using CinemaApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            bool correctSize = false;
            CinemaRoomController controller = new CinemaRoomController(); ;
            // Display title as the C# console calculator app.
            Console.WriteLine("Cinema Application in C#\r");
            Console.WriteLine("------------------------\n");

            while (!correctSize)
            {
                var numbers = StartUpCinemaRoom();
                if (numbers[0] == 0 || numbers[1]==0)
                {
                    Console.WriteLine("Rows and seats must be positive integers!" );
                }
                else
                {
                    controller = new CinemaRoomController((numbers[0]), numbers[1]);
                    correctSize = true;
                }
            }

            while (!endApp)
            {
                ShowInputOptions();
                string output = Console.ReadLine();
                try
                {
                    controller.ChooseAction(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong - here are the details: " + ex.Message);
                }
                Console.WriteLine("------------------------\n");
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n"); // Friendly linespacing.
            }
        }
        public static void ShowInputOptions()
        {
            //show 3 options--> 
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\tc - Show Cinema Room");
            Console.WriteLine("\tb - Buy a ticket");
            Console.WriteLine("\ts - Show Cinema Room statistics");
            Console.Write("Your option? ");
        }
        public static List<int> StartUpCinemaRoom()
        {
            Console.WriteLine("To create a Cinema room, enter number of Rows and Seats.");
            Console.WriteLine("Please enter numbers, comma-separated: ");
            return Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToList();
        }
    }
}
