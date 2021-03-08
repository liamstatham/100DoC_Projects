using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
