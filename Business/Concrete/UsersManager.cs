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

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll()); 
            
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_usersDal.Get(u=> u.Id == id));
        }

        public IResult Add(Users users)
        {
            _usersDal.Add(users);
            
            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            
            return new SuccessResult(Messages.UsersUpdated);
        }

        public IResult Delete(Users users)
        {
            _usersDal.Delete(users);
            
            return new SuccessResult(Messages.UsersDeleted);
        }
    }
}
