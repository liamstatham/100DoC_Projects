using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurntData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurntData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            // using system.linq r=> r.Name makes the list asceding
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
