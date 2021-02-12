using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUsersService
    {

        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int id);
        IResult Add(Users users);
        IResult Update(Users users);
        IResult Delete(Users users);
    }
}
