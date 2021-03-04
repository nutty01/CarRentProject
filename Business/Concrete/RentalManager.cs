using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Rental rental)
        {
            

            if (rental.ReturnDate==null)
            {
                return new ErrorResult(Messages.CarNotAvailable);
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
    }
}
