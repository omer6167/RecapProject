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

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetails());
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalsDal.Get(r => r.Id == id));
        }

        [Obsolete("Kullanılmıyor")]
        public IResult Add(Rentals entity)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Kullanılmıyor")]
        public IResult Update(Rentals entity)
        {
            throw new NotImplementedException();
        }

        public IResult Rent(Rentals rentals)
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

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalDeleted);
        }
    }
}

