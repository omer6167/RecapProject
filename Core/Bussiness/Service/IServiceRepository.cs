using System.Collections.Generic;
using Core.Utilities.Results.Abstract;

namespace Core.Bussiness.Service
{
    public interface IServiceRepository<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}