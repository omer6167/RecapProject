using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> expressionFilter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return expressionFilter == null
                    ? context.Brand.ToList()
                    : context.Brand.Where(expressionFilter).ToList();
            }
        }
        

        public Brand GetById(Expression<Func<Brand, bool>> expressionFilter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Brand.SingleOrDefault(expressionFilter);
            }
        }

        public void Add(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
            }
        }

        public void Update(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }

        public void Delete(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
            }
        }
    }
}
