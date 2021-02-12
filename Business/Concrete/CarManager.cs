using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants.Concrete;
using Business.ValidationRule.CustomValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            //Bussiness Code

            //Dal Code
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            //Bussiness Code

            //Dal Code
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {

            //Bussiness Code

            //Dal Code
            return new  SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }

        public IResult Add(Car car)
        {

            //Bussiness Code
            try
            {
                CarValidator.ValidateNameLength(car);
                CarValidator.ValidateDailyPrice(car);
            }
            catch (Exception e)
            {
                return new ErrorResult($"{Messages.ColorAddError} , {e.Message}");
            }
            //Dal Code
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {

            //Bussiness Code

            //Dal Code
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {

            //Bussiness Code

            //Dal Code
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
