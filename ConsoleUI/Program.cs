using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager();

            foreach (var car in carManager.GetByUnitCars(20000,30000))
            {
                Console.WriteLine(car.Description + " $"+ car.DailyPrice);
            }
            
        }
    }
}
