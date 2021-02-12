using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string  BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public override string ToString()
        {
            return $"CarName: {CarName}, CompanyName: {CompanyName}, BrandName: {BrandName}, RentDate: {RentDate}, ReturnDate: {ReturnDate}";
        }
    }
}
