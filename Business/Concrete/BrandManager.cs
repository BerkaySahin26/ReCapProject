using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }
        public IResult Add (Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _BrandDal.Add(brand);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult<List<Brand>>(_BrandDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_BrandDal.Get(p => p.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
