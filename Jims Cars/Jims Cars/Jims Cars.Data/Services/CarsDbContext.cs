using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Jims_Cars.Data.Models;

namespace Jims_Cars.Data.Services
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
    }
}
