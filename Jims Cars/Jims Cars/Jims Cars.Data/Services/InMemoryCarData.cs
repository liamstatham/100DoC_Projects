using Jims_Cars.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jims_Cars.Data.Services
{
    public class InMemoryCarData : ICarData
    {
        List<Cars> carslist;

        public InMemoryCarData()
        {
            carslist = new List<Cars>()
            {
                new Cars {Id = 1, Brand = "HotWheels", Name = "Favourite Car", Colour = Colour.Silver},
                new Cars {Id = 2, Brand = "HotWheels", Name = "Jims Car", Colour = Colour.Blue },
                new Cars {Id = 3, Brand = "Cars", Name = "Lightning Mcqueen", Colour = Colour.Red}
            };
        }

        public Cars Get(int id)
        {
            return carslist.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cars> GetCars()
        {
            return carslist.OrderBy(c => c.Name);
        }

        public void Add(Cars car)
        {
            carslist.Add(car);
            car.Id = carslist.Max(r => r.Id + 1);
        }
    }
}
