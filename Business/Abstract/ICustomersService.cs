using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<List<Customers>> GetAll();
        IDataResult<Customers> GetById(int userId);
        IResult Add(Customers customers);
        IResult Update(Customers customers);
        IResult Delete(Customers customers);
    }
}
