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
      
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetail();
     
    }
}
