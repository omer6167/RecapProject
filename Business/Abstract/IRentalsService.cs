using System;
using System.Collections.Generic;
using System.Text;
using Core.Business.Service;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalsService : IServiceRepository<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Rent(Rental rentals);
        IResult UpdateReturnDate(int carId);
        
       
    }
}
