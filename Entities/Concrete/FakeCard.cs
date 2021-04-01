using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class FakeCard : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }

        public string Cvv { get; set; }

        public string ExpirationDate { get; set; }

        public decimal Balance { get; set; }
    }
}