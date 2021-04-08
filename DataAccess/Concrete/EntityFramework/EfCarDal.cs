using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using var context = new RentACarContext();
            var result =
                from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join color in context.Colors
                    on car.ColorId equals color.Id
                select new CarDetailDto
                {
                    Id = car.Id,
                    CarName = car.Name,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    MinFindeksScore = car.MinFindeksScore
                    
                };
            return result.ToList();
        }
        public CarDetailDto GetCarDetailById(int carId)
        {
            using var context = new RentACarContext();
            var result =
                from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join color in context.Colors
                    on car.ColorId equals color.Id
                where car.Id == carId
                select new CarDetailDto
                {
                    Id = car.Id,
                    CarName = car.Name,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    MinFindeksScore = car.MinFindeksScore
                };
            return result.ToList()[0];
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {

            using var context = new RentACarContext();
            var result =
                from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join color in context.Colors
                    on car.ColorId equals color.Id
                where car.ColorId == colorId
                select new CarDetailDto
                {
                    Id = car.Id,
                    CarName = car.Name,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description
                };
            return result.ToList();
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using var context = new RentACarContext();
            var result =
                from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.Id
                join color in context.Colors
                    on car.ColorId equals color.Id
                where car.BrandId == brandId
                select new CarDetailDto
                {
                    Id = car.Id,
                    CarName = car.Name,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description
                };
            return result.ToList();
        }


    }
}
