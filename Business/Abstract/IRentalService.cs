using Core.Business.Service;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService : IServiceRepository<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Rent(Rental rentals);
        IResult UpdateReturnDate(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId);
        IDataResult<List<Rental>> GetByCarId(int id);
        IDataResult<List<Rental>> GetByCustomerId(int id);
        IResult IsRentable(int carId);
    }
}
