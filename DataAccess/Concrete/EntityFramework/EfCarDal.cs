using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using var context = new RentACarContext();
            var result =
                from car in context.Car
                    join brand in context.Brand
                        on car.BrandId equals brand.Id
                    join color in context.Color
                        on car.ColorId equals color.Id
                select new CarDetailDto
                {
                    CarName = car.Name,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice
                };
            return result.ToList();
        }
    }
}
