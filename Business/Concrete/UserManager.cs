using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UsersUpdated);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult(Messages.UsersDeleted);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult UpdateInfos(User user)
        {
            User userInfos = GetById(user.Id).Data;

            userInfos.FirstName = user.FirstName;
            userInfos.LastName = user.LastName;
            userInfos.Email = user.Email;

            _userDal.Update(userInfos);

            return new SuccessResult(Messages.UsersUpdated);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            User user = _userDal.Get(u => string.Equals(u.Email, email));

            if (user == null)
            {
                return new ErrorDataResult<User>();
            }

            return new SuccessDataResult<User>(user);

        }

    }
}
