using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRule.CustomValidation
{
    public class CarValidator
    {
        public static void ValidateNameLength(Car car)
        {
            if (car.Name.Length <2)
            {
                throw new Exception("Car's Name's length cannot be smaller than two");
            }
        }

        public static void ValidateDailyPrice(Car car)
        {
            if (car.DailyPrice<=0)
            {
                throw new Exception("Daily price must be bigger than zero");
            }
        }

    }
}
