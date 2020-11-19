using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public class SizeOfRoom
    {
        public int NrOfRows { get; set; }
        public int SeatsPerRow { get; set; }
        public SizeOfRoom(int rows, int seatsPerRow)
        {
            NrOfRows = rows;
            SeatsPerRow = seatsPerRow;
        }
    }
}
