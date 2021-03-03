using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetById(int id);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetByUnitCars(decimal min, decimal max);
        List<CarDetailDto> GetCarDetails();

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
