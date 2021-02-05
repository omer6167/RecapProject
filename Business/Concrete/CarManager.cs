using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.ValidationRule.CustomValidation;
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

        public Car GetById(int id)
        {
            //Bussiness Code

            //Dal Code
            return _carDal.GetById(c=> c.Id ==id);
        }

        public List<Car> GetByBrandId(int id)
        {

            //Bussiness Code

            //Dal Code
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car car)
        {

            //Bussiness Code
            try
            {
                CarValidator.ValidateNameLength(car);
                CarValidator.ValidateDailyPrice(car);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
