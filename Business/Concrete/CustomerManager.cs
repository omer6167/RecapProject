using Business.Abstract;
using Business.Constants.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customersDal;

        public CustomerManager(ICustomerDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll());
        }

        public IDataResult<Customer> GetById(int userId)
        {
            return new SuccessDataResult<Customer>(_customersDal.Get(c => c.UserId == userId));
        }

        public IResult Add(Customer customers)
        {
            _customersDal.Add(customers);
            
            return new SuccessResult(Messages.CustomersAdded);
        }

        public IResult Update(Customer customers)
        {
            _customersDal.Update(customers);

            return new SuccessResult(Messages.CustomersUpdated);
        }

        public IResult Delete(Customer customers)
        {
            _customersDal.Delete(customers);

            return new SuccessResult(Messages.CustomersDeleted);
        }

        public IDataResult<UserDetailDto> GetByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(_customersDal.GetCustomerOfUser(email));
        }
    }
}
