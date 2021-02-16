using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<Rentals> GetById(int id);
        IResult Rent(Rentals rentals);
        IResult UpdateReturnDate(int carId);
        IResult Delete(Rentals rentals);
       
    }
}
