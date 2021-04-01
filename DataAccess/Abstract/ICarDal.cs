using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal :IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
        List<CarDetailDto> GetCarDetailByColorId(int colorId);
        List<CarDetailDto> GetCarDetailByBrandId(int brandId);
        CarDetailDto GetCarDetailById(int carId);
    }
}
