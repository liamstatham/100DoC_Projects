﻿using Jims_Cars.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jims_Cars.Data.Services
{
    public class InMemoryCarData : ICarData
    {
        List<Cars> cars;

        public InMemoryCarData()
        {
            cars = new List<Cars>()
            {
                new Cars {Id = 1, Brand = "HotWheels", Name = "Favourite Cars", Colour = Colour.Silver},
                new Cars {Id = 2, Brand = "HotWheels", Name = "Jims Cars", Colour = Colour.Blue },
                new Cars {Id = 3, Brand = "Cars", Name = "Lightning Mcqueen", Colour = Colour.Red}
            };
        }

        public Cars Get(int id)
        {
            return cars.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cars> GetCars()
        {
            return cars.OrderBy(c => c.Name);
        }

        public void Add(Cars car)
        {
            cars.Add(car);
            car.Id = cars.Max(r => r.Id + 1);
        }

        public void Update(Cars car)
        {
            var existing = Get(car.Id);
            if(existing != null)
            {
                existing.Brand = car.Brand;
                existing.Name = car.Name;
                existing.Colour = car.Colour;
            }
        }
    }
}
