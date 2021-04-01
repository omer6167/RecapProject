using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FakeCardManager : IFakeCardService
    {
        private IFakeCardDal _fakeCardDal;

        public FakeCardManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }

      

        public IDataResult<List<FakeCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll());
        }

        public IDataResult<FakeCard> GetById(int cardId)
        {
            return new SuccessDataResult<FakeCard>(_fakeCardDal.Get(c => c.Id == cardId));
        }

        public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(c => c.Number == cardNumber));
        }

        public IResult IsCardExist(FakeCard fakeCard)
        {
            var result = _fakeCardDal.Get(fc => 
                fc.Name == fakeCard.Name && 
                fc.Number == fakeCard.Number && 
                fc.ExpirationDate==fakeCard.ExpirationDate  && 
                fc.Cvv == fakeCard.Cvv);
            
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        
        public IResult Add(FakeCard fakeCard)
        {
            _fakeCardDal.Add(fakeCard);
            return new SuccessResult();
        }

        public IResult Delete(FakeCard fakeCard)
        {
            _fakeCardDal.Delete(fakeCard);
            return new SuccessResult();
        }

        public IResult Update(FakeCard fakeCard)
        {
            _fakeCardDal.Update(fakeCard);
            return new SuccessResult();
        }
    }
}
