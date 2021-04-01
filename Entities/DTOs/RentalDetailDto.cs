using System;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FakeCardId { get; set; }
        public string CarName { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public override string ToString()
        {
            return $"CarName: {CarName}, CompanyName: {CompanyName}, BrandName: {BrandName}, FullName: {FullName}, RentDate: {RentDate}, ReturnDate: {ReturnDate}";
        }
    }
}
