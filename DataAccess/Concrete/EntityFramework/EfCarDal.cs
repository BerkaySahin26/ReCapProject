using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,SqlContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join d in context.Colors
                             on p.ColorId equals d.ColorId
                             select new CarDetailDto
                             {
                                 CarName = p.CarName,
                                 BrandName = c.BrandName,
                                 ColorName = d.ColorName,
                                 DailyPrice = p.DailyPrice
                             };

                return result.ToList();
            }
        }

      
    }
}
