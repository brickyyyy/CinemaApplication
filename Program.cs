using CinemaApplication.Controllers;
using System;
using System.Linq;

namespace CinemaApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Cinema Application in C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("To create a Cinema room, enter number of Rows and Seats.");
            Console.WriteLine("Please enter numbers, comma-separated: ");
            var numbers = Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToList();
            var controller = new CinemaRoomController((numbers[0]), numbers[1]);
            while (!endApp)
            {
                ShowInputOptions();
                string output = Console.ReadLine();
                //TODO: finish selection
                //https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019
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
    }
}
