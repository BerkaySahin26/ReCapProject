﻿using Business.Abstract;
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

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        IDataResult<List<Car>> ICarService.GetAll()
        {
           if ( DateTime.Now.Hour ==18)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
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
        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _CarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
    }
}
