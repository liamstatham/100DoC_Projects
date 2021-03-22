using Jims_Cars.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jims_Cars.Data.Services
{
    public class SqlCarData : ICarData
    {
        private readonly CarsDbContext db;

        public SqlCarData(CarsDbContext db)
        {
            this.db = db;
        }
        public void Add(Cars car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
        }

        public Cars Get(int id)
        {
            return db.Cars.FirstOrDefault(c => c.Id == id);

        }

        public IEnumerable<Cars> GetCars()
        {
            return from c in db.Cars
                   orderby c.Name
                   select c;
        }

        public void Update(Cars car)
        {
            var entry = db.Entry(car);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
