using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public UserDetailDto GetCustomerOfUser(string email)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             where u.Email == email
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 Name = u.FirstName + ' ' + u.LastName,
                                 Email = u.Email,
                                 FindeksScore = c.FindeksScore,
                                 CompanyName = c.CompanyName
                             };

                return result.SingleOrDefault();
            }

            
        }
    }
}
