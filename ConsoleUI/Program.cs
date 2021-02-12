using System;
using System.ComponentModel.Design;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            


            foreach (var dto in carManager.GetCarDetail())
            {
                Console.WriteLine(dto);
            }

           


            //    switch (key.Key)
            //    {
            //        case ConsoleKey.NumPad1 :
            //            Console.WriteLine(Menu());
            //            break;
            //        case ConsoleKey.NumPad2:
            //            Console.WriteLine(CarMenu());
            //            break;
            //        case ConsoleKey.Escape:
            //            Environment.Exit(0);
            //            break;
            //    }


            //} while (true);


            Console.ReadLine();
        }

        //public static string Menu()
        //{
        //    return $" *************\n press 1 For Car \n press 2 For Color \n press 3 For Brand";
        //}
        //public static string CarMenu()
        //{
        //    return $" *************\n press 1 Add Car \n press 2 Update Color \n press 3 Delete Brand";
        //}
        //public static string BrandMenu()
        //{
        //    return $" *************\n press 1 Add Brand \n press 2 Update Brand \n press 3 Delete Brand";
        //}
        //public static string ColorMenu()
        //{
        //    return $" *************\n press 1 Add Color \n press 2 Update Color \n press 3 Delete Color";
        //}
    }
}
