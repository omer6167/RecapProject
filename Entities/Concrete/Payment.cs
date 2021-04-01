using Core.Entities;

namespace Entities.Concrete
{
    public class Payment :IEntity
    {
        public int Id { get; set; }
        public int FakeCardId { get; set; }
        public decimal Price { get; set; }
    }
}