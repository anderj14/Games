
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class GameConsole : BaseEntity
    {
        public string ConsoleName { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int TechnicalSpecificationId { get; set; }
        public TechnicalSpecification TechnicalSpecification { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}