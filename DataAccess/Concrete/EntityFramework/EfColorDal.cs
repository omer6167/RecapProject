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
    public class EfColorDal : IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> expressionFilter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return expressionFilter == null
                    ? context.Color.ToList()
                    : context.Color.Where(expressionFilter).ToList();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> expressionFilter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Color.SingleOrDefault(expressionFilter);
            }
        }

       

        public void Add(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
            }
        }

        public void Update(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }

        public void Delete(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deleteedEntity = context.Entry(entity);
                deleteedEntity.State = EntityState.Deleted;
            }
        }
    }
}
