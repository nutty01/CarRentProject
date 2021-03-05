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
            //CarTest();
            //
            //GetRentalDetails();

            //RentalAdd();

            //CustomerAdd();
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.Add(new Customer {CompanyName = "Star", UserId = 5});
            Console.WriteLine(result.Message);
        }

        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetRentalDetail().Data)
            {
                Console.WriteLine( "Car Name: {0},  RentDate: {1}, ReturnDate: {2} ", rental.CarName,rental.RentDate.Date,rental.ReturnDate);
            }
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

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, RentDate = new DateTime(2021,02,02) });
            Console.WriteLine(result.Message);
        }


    }
}
