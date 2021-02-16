using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        public IDataResult<List<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Users users)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Users users)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
