﻿using Jims_Cars.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jims_Cars.Data.Models
{
    public class Cars
    {
        // car id
        public int Id { get; set; }

        // car brand
        public CarMake Brand
        {
            get { return Brand; }
            set { Brand = value; }
        }

        // Car name
        [Required]
        public string Name { get; set; }

        // Car colour
        public Colour Colour { get; set; }

    }
}
