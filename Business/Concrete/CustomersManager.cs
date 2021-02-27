using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomersManager : ICustomersService
    {
        private ICustomersDal _customersDal;

        public CustomersManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll());
        }

        public IDataResult<Customers> GetById(int userId)
        {
            return new SuccessDataResult<Customers>(_customersDal.Get(c => c.UserId == userId));
        }

        public IResult Add(Customers customers)
        {
            _customersDal.Add(customers);
            
            return new SuccessResult(Messages.CustomersAdded);
        }

        public IResult Update(Customers customers)
        {
            _customersDal.Update(customers);

            return new SuccessResult(Messages.CustomersUpdated);
        }

        public IResult Delete(Customers customers)
        {
            _customersDal.Delete(customers);

            return new SuccessResult(Messages.CustomersDeleted);
        }
    }
}
