using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
         ICarDal _carDal;

         public CarManager(ICarDal carDal)
         {
             _carDal = carDal;
         }

         public IDataResult<List<CarDetailDto>> GetCarDetails()
         {
             return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails()) ;
         }

         public IDataResult<List<CarDetailDto>> GetCarDetailById(int id)
         {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(p => p.Id == id).ToList());
        }

         [SecuredOperation("car.add,admin")]
         [ValidationAspect(typeof(CarValidator))]
         [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
         {
             _carDal.Add(car);

             return new SuccessResult(Messages.CarAdded);
         }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
         {
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
         }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Car>> GetByUnitCars(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().FindAll(c=>c.BrandId==brandId).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails().FindAll(c => c.ColorId == id).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId,int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().FindAll(c => c.BrandId == brandId && c.ColorId==colorId));
        }

    }
}
