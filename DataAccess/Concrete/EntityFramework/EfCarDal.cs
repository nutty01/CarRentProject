using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{   
    public class EfCarDal: EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id
                    join ci in context.CarImages on c.Id equals ci.CarId
                    select new CarDetailDto
                    {
                        Id = c.Id,  CarName = c.Description, BrandId = c.BrandId, BrandName = b.Name, ColorId = c.ColorId, ColorName = co.Name,DailyPrice = c.DailyPrice, ModelYear =c.ModelYear, ImagePath=ci.ImagePath
                    };

                return result.ToList();
            }

            
        }
    }
}
