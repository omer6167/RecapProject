using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int MinFindeksScore { get; set; }


        public override string ToString()
        {
            return $"CarName: {CarName}, BrandName: {BrandName},ColorName: {ColorName},DailyPrice: {DailyPrice}";
        }
    }
}
