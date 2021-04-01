using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {

        public int Id { get; set; }
        public int CarId { get; set; }

        public int FakeCardId { get; set; }

        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        //[AllowNull]
        public DateTime? ReturnDate { get; set; }
        public decimal Price { get; set; }
    }
}
