using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemorCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemorCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=3401,Description="BMW",ModelYear = "2013"},
                new Car {Id=2,BrandId=1,ColorId=2,DailyPrice=5401,Description="MERCEDES",ModelYear = "2016"},
                new Car {Id=3,BrandId=2,ColorId=3,DailyPrice=4401,Description="FİAT",ModelYear = "2017"},
                new Car {Id=4,BrandId=2,ColorId=4,DailyPrice=2401,Description="FORD",ModelYear = "2018"},
                new Car {Id=5,BrandId=3,ColorId=5,DailyPrice=7401,Description="OPEL",ModelYear = "2014"},

            };
        }

        public void Add(Car car)
        {
           _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=> p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
