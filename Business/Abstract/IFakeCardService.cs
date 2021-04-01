using System.Collections.Generic;
using Core.Business.Service;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{

    public interface IFakeCardService : IServiceRepository<FakeCard>
    {
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);

        IResult IsCardExist(FakeCard fakeCard);

    }


}