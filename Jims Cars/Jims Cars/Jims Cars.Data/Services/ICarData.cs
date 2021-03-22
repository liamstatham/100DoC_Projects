using System;
using System.Collections.Generic;
using Jims_Cars.Data.Models;
using System.Text;

namespace Jims_Cars.Data.Services
{
    public interface ICarData
    {
        IEnumerable<Cars> GetCars();
        Cars Get(int id);

        void Add(Cars car);

        void Update(Cars car);

        void Delete(int id);

    }
}
