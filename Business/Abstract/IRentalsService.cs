using System;
using System.Collections.Generic;
using System.Text;
using Core.Bussiness.Service;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalsService : IServiceRepository<Rentals>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Rent(Rentals rentals);
        IResult UpdateReturnDate(int carId);
        
       
    }
}
