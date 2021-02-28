using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        private IRentalsDal _rentalsDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(r => r.Id == id));
        }

        [Obsolete("Kullanılmıyor")]
        public IResult Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Kullanılmıyor")]
        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult Rent(Rental rentals)
        {
            var result = _rentalsDal.CheckCarId(rentals.CarId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.RentalUpdatedErorr);
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
    }
}

