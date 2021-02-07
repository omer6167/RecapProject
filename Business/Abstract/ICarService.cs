using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetByBrandId(int id);
        List<Car> GetByColorId(int id);
        List<CarDetailDto> GetCarDetail();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
