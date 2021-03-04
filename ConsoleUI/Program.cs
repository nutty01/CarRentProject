using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();


        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            //carManager.Add(new Car {BrandId = 4, DailyPrice = 35000, ColorId = 5, Description = "500L", ModelYear = 2020});
            //carManager.Update(new Car
            //    {Id = 8, BrandId = 4, DailyPrice = 35000, ColorId = 5, Description = "500L", ModelYear = 2020});

            //foreach (var car in carManager.GetByUnitCars(20000, 30000))
            //{
            //    Console.WriteLine(car.Description + " $" + car.DailyPrice);
            //}

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car Name: {0} -- Brand Name: {1} -- Color Name: {2} -- Daily Price: {3}" ,car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }
        }
    }
}
