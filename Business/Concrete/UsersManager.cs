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
    public class UsersManager : IUsersService
    {
        private IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll()); 
            
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_usersDal.Get(u=> u.Id == id));
        }

        public IResult Add(User users)
        {
            _usersDal.Add(users);
            
            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Update(User users)
        {
            _usersDal.Update(users);
            
            return new SuccessResult(Messages.UsersUpdated);
        }

        public IResult Delete(User users)
        {
            _usersDal.Delete(users);
            
            return new SuccessResult(Messages.UsersDeleted);
        }
    }
}
