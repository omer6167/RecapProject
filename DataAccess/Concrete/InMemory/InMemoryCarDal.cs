using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car() { Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 200,Description = "New Car"},
                new Car() { Id = 2,BrandId = 1,ColorId = 1,DailyPrice = 300,Description = "Old Fashion car"},
                new Car() { Id = 3,BrandId = 1,ColorId = 2,DailyPrice = 250,Description = "Classic car"},
                new Car() { Id = 4,BrandId = 2,ColorId = 2,DailyPrice = 50, Description = "New Sport Car"},
                new Car() { Id = 5,BrandId = 2,ColorId = 2,DailyPrice = 100,Description = "Old Fox"}
            };
        }
        

        

        public List<Car> GetAll(Expression<Func<Car, bool>> expressionFilter = null)
        {
            return  expressionFilter == null
                ? _cars.ToList()
                : _cars.Where(expressionFilter.Compile()).ToList();
        }

        public Car Get(Expression<Func<Car, bool>> expressionFilter)
        {
            //Func<Car, bool> func = expressionFilter.Compile();
            //Predicate<Car> pred = func.Invoke;
            //return _cars.Find(pred);

            //OR

            //Func<Car, bool> func = expressionFilter.Compile();
            //Predicate<Car> pred = func.Invoke;
            return _cars.SingleOrDefault(expressionFilter.Compile());

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car updCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (updCar == null) return;
            updCar.BrandId = car.BrandId;
            updCar.ColorId = car.ColorId;
            updCar.DailyPrice = car.DailyPrice;
            updCar.ModelYear = car.ModelYear;
            updCar.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car delCar = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(delCar);
        }
    }
}
