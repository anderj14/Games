
namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string CountryOrigin { get; set; }
        public int YearFounded { get; set; }
    }
}