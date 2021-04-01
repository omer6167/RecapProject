using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {

        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        #region BussinessRules


        #endregion

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            _paymentDal.GetAll();

            return new SuccessDataResult<List<Payment>>();
        }


        #region Other Dal Works ara not implemented

       

        public IDataResult<Payment> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public IResult Update(Payment entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Payment entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}