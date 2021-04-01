using System;
using System.Collections.Generic;
using System.Text;
using Core.Business.Service;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService : IServiceRepository<Car>
    {
      
        IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);

        IDataResult<CarDetailDto> GetCarDetailById(int carId);
    }
}
