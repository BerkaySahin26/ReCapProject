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

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public IDataResult<List<Car>>GetAll()
        {
           //if ( DateTime.Now.Hour ==18)
           // {
           //     return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
           // }
           return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.CarsListed);
        }

         IDataResult< List<Car>> ICarService.GetCarsByBrandId(int id)
        {
           return new SuccessDataResult<List<Car>> (_CarDal.GetAll(p=>p.BrandId == id));
        }

         IDataResult< List<Car>> ICarService.GetCarsByColorId(int id)
        {
           return new SuccessDataResult<List<Car>>( _CarDal.GetAll(p=>p.ColorId == id));
        }

       public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 17)
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
    }
}
