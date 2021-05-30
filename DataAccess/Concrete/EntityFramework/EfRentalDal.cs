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
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RentCarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                    join r in context.Rentals on c.Id equals r.CarId
                    join cu in context.Customers on r.CustomerId equals cu.Id
                    join u in context.Users on cu.UserId equals u.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    select new RentalDetailDto
                    {
                        CarName = b.Name+" "+ c.Description, UserName=u.FirstName+" "+u.LastName, CompanyName=cu.CompanyName, Id = r.Id, RentDate = r.RentDate,ReturnDate = r.ReturnDate
                    };
                return result.ToList();

            }
        }
    }
}
