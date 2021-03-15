using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,RentACarContext> , IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using var context = new RentACarContext();
            var result =
                from rentals in context.Rentals
                    join customer in context.Customers
                        on rentals.CustomerId equals customer.UserId
                    join users in context.Users
                        on customer.UserId equals users.Id
                    join car in context.Cars
                        on rentals.CarId equals car.Id
                    join brand in context.Brands 
                        on car.BrandId equals brand.Id
                select new RentalDetailDto
                {
                    BrandName = brand.Name,
                    FullName = users.FirstName + users.LastName,
                    CarName = car.Name,
                    CompanyName = customer.CompanyName,
                    RentDate = rentals.RentDate,
                    ReturnDate = (DateTime) rentals.ReturnDate
                };
            return result.ToList();
        }

        public IDataResult<int> CheckCarId(int carId)
        {
            using var context = new RentACarContext();
            var result =
                from rentals in context.Rentals
                where carId == rentals.CarId && rentals.RentDate == null
                select rentals.CarId;
            
            if (result.Any())
            {
                return new ErrorDataResult<int>(result.Count());
            }

            return new SuccessDataResult<int>(result.Count());
        }

        public IDataResult<Rental> CheckReturnDate(int carId)
        {
            using var context = new RentACarContext();
            var result =
                from rentals in context.Rentals
                where carId == rentals.CarId && rentals.RentDate == null
                select new Rental
                {
                    Id = rentals.Id,
                    CarId = rentals.CarId,
                    RentDate = rentals.RentDate,
                    ReturnDate = rentals.ReturnDate
                };
            
            if (result == null)
            {
                return new ErrorDataResult<Rental>(result.LastOrDefault());
            }

            return new SuccessDataResult<Rental>(result.LastOrDefault());
        }
    }
}
