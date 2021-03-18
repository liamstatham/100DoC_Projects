using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
