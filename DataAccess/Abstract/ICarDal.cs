using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        Car GetById(int ıd);
        List<Car> GetByBrandId(int ıd);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
