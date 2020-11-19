using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public static class Utilities
    {
        public static double RoundUp (double value)
        {
            return Math.Round(value, MidpointRounding.AwayFromZero); ;
        }
        public static double RoundDown (double value)
        {
            return Math.Floor(value); ;
        }
    }
}
