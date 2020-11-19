using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public class Cinema
    {
        public int NrOfRooms { get; set; }
        public string Name { get; }

        public Cinema(int nrOfRooms)
        {
            NrOfRooms = nrOfRooms;
            Name = "Valentina's awesome cinema";
        }

    }
}
