using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalsDal : IEntityRepository<Rentals>
    {
        List<RentalDetailDto> GetRentalDetails();
        int CheckCarId(int carId);
        Rentals CheckReturnDate(int carId);
    }
}
