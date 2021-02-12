﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals,RentACarContext> , IRentalsDal
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
                    join car in context.Car
                        on rentals.CarId equals car.Id
                    join brand in context.Brand 
                        on car.BrandId equals brand.Id
                select new RentalDetailDto
                {
                    BrandName = brand.Name,
                    CustomerName = users.Name,
                    CarName = car.Name,
                    CompanyName = customer.CompanyName,
                    RentDate = rentals.RentDate,
                    ReturnDate = rentals.ReturnDate
                };
            return result.ToList();
        }
    }
}
