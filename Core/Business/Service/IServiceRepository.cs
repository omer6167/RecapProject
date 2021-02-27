using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Service
{
    public interface IServiceRepository<T> where T : IEntity
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}