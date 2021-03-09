using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
         IRentalDal _rentalDal;

         public RentalManager(IRentalDal rentalDal)
         {
             _rentalDal = rentalDal;
         }

         public IDataResult<List<Rental>> GetAll()
         {
             return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
         }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarIsAvailable(rental));
            if (result !=null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail());
        }

        private IResult CheckIfCarIsAvailable(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var result in results)
            {
                if (result.ReturnDate==null || rental.RentDate<result.ReturnDate)
                {
                    return new ErrorResult(Messages.CarNotAvailable);
                }
                
            }
            return new SuccessResult();
        }

    }
}
