using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> expressionFilter = null);

        T GetById(Expression<Func<T, bool>> expressionFilter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
