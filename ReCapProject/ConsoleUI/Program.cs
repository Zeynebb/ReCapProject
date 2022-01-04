using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities;
using Entities.Abstract;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerAddTest();
            //CarAddTest();
            //RentalAddTest();
            //CarTest();
            //ColorTest();
            //BrandTest();

        }

        private static void RentalAddTest()
        {
            Rental rental = new Rental()
            {
                CarId = 1,
                UserId = 2,
                RentDate = DateTime.Now
            };

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental);
        }

        private static void CarAddTest()
        {
            Car car = new Car()
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 2000,
                Description = "Mercedes",
                ModelYear = 2019
            };
        }

        private static void CustomerAddTest()
        {
            Customer customer = new Customer
            {
                //UserId =1,
                FirstName = "Zeyneb Eda",
                LastName = "YILMAZ",
                CompanyName = "kodlama.io",
                Email = "zeynebedayilmaz@hotmail.com",
                Password = "123321"
            };
            Customer customer1 = new Customer
            {
                FirstName = "Zeyneb",
                LastName = "YILMAZ",
                CompanyName = "zey",
                Email = "zeyneb@hotmail.com",
                Password = "123123"
            };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer1);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
