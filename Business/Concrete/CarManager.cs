using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //Bussiness Code

            //Dal Code

            return _carDal.GetAll();
        }

        public Car GetById(int ıd)
        {

            //Bussiness Code

            //Dal Code
            return _carDal.GetById(ıd);
        }

        public List<Car> GetByBrandId(int ıd)
        {

            //Bussiness Code

            //Dal Code
            return _carDal.GetByBrandId(ıd);
        }

        public void Add(Car car)
        {

            //Bussiness Code

            //Dal Code
            _carDal.Add(car);
        }

        public void Update(Car car)
        {

            //Bussiness Code

            //Dal Code
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {

            //Bussiness Code

            //Dal Code
            _carDal.Delete(car);
        }
    }
}
