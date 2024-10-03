using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
        ICarDal _CarDal;
        IBrandService _brandService;
        IColorService _colorService;

        public CarManager(ICarDal carDal, IBrandService brandService, IColorService colorService)
        {
            _CarDal = carDal;
            _brandService = brandService;
            _colorService = colorService;
        }

        public IDataResult<List<Car>>GetAll()
        {
           //if ( DateTime.Now.Hour ==18)
           // {
           //     return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
           // }
           return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.BrandId == brandId).ToList());
        }

       

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails(), Messages.CarsListed);
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExists(car.CarName));
            if (result == null)
            {
                return result;
            }
            _CarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.Id == id));
        }

      
       private IResult CheckIfCarNameExists(string carName)
        {
            var result = _CarDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");

            }
            Add(car);
            return null;
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.ColorId == colorId).ToList());
        }
    }
}
