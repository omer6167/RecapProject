using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        User GetByMail(string email);


        IResult UpdateInfos(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetById(int id);
    }
}