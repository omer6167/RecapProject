using Business.Abstract;
using Business.Constants.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalsDal;

        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll());
        }


        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetails(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(r => r.CarId == id));
        }

        public IDataResult<List<Rental>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(r => r.CustomerId == id));
        }


        public IResult Rent(Rental rentals)
        {

            var result = IsRentable(rentals.CarId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            
            _rentalsDal.Add(rentals);
            return new SuccessResult(Messages.RentalAdded);
        }

        
        
        public IResult UpdateReturnDate(int carId) 
        {
            var result = _rentalsDal.CheckReturnDate(carId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.RentalUpdatedErorr);
            }

            result.Data.ReturnDate = DateTime.Now;
            _rentalsDal.Update(result.Data);

            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult IsRentable(int carId)
        {
            var checkReturnDate = _rentalsDal.CheckReturnDate(carId); //Succesfull
            if (!checkReturnDate.Success)
            {
                return new ErrorResult(Messages.IsNotRentable);
            }

            //var result = _rentalsDal.CheckCarId(carId);
            //if (!result.Success)
            //{
            //    return new ErrorResult(Messages.RentalUpdatedErorr);
            //}

            return new SuccessResult();
        }


        #region OBSOLOTE METHODS

        [Obsolete("Kullanılmıyor(Rent Fonksiyonunu Kullanın)")]
        public IResult Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Kullanılmıyor(UpdateReturnDate Fonksiyonunu Kullanın")]
        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }



        #endregion

    }
}

