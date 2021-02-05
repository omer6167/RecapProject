using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> expressionFilter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return expressionFilter==null 
                        ? context.Car.ToList() 
                        : context.Car.Where(expressionFilter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> expressionFilter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Car.SingleOrDefault(expressionFilter);
            }

        }

        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
            }
        }
    }
}
