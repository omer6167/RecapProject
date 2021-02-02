using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car1 = new Car { Id = 1 };
            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }


            Car car2 = new Car { Id = 2, Description = "My new Description" };
            carManager.Update(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Car car3 = new Car { Id = 6, Description = "My new AddingCar" };
            carManager.Add(car3);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }


            Console.ReadLine();
        }
    }
}
