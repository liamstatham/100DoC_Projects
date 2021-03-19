using Jims_Cars.Data.Models;
using System;

namespace Jims_Cars.Data.Models
{
    public class Cars
    {
        // car id
        public int Id { get; set; }

        // car brand
        public string Brand { get; set; }

        // Car name
        public string Name { get; set; }

        // Car colour
        public Colour Colour { get; set; }

    }
}
