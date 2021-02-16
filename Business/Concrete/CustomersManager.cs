using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomersManager : ICustomersService
    {
        public IDataResult<List<Customers>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customers> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Customers customers)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customers customers)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customers customers)
        {
            throw new NotImplementedException();
        }
    }
}
