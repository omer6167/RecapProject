using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using var context = new RentACarContext();
            var result =
                from rentals in filter == null 
                    ? context.Rentals
                    : context.Rentals.Where(filter)
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
                    Id = rentals.Id,
                    CarId = car.Id,
                    BrandName = brand.Name,
                    FullName = users.FirstName + " " + users.LastName,
                    CarName = car.Name,
                    CompanyName = customer.CompanyName,
                    RentDate = rentals.RentDate,
                    ReturnDate = (DateTime)rentals.ReturnDate,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    Price = rentals.Price,
                    FakeCardId = rentals.FakeCardId
                };
            return result.ToList();
        }

        [Obsolete("Useless,will be refactoring")]
        public IDataResult<int> CheckCarId(int carId) //
        {
            int a=0;
            using var context = new RentACarContext();
            var result =
                from rentals in context.Rentals
                where carId == rentals.CarId && rentals.RentDate == null
                select a == rentals.CarId;

            if (!result.Any())
            {
                return new SuccessDataResult<int>(result.Count());
            }
            return new ErrorDataResult<int>(result.Count());
            
        }

        public IDataResult<Rental> CheckReturnDate(int carId)
        {
            using var context = new RentACarContext();
            var result =
                from rentals in context.Rentals
                where carId == rentals.CarId  && rentals.ReturnDate == null
                select new Rental
                {
                    Id = rentals.Id,
                    CarId = rentals.CarId,
                    RentDate = rentals.RentDate,
                    ReturnDate = rentals.ReturnDate
                };

            if (!result.Any())
            {
                return new SuccessDataResult<Rental>(result.SingleOrDefault());
            }
            return new ErrorDataResult<Rental>(result.SingleOrDefault());
        }
    }
}
