using System.Collections.Generic;
using Core.Business.Service;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImagesService 
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetByCarId(int carId);
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImages);
    }
}