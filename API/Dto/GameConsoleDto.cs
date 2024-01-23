
using Core.Entities;

namespace API.Dto
{
    public class GameConsoleDto
    {
        public int Id { get; set; }
        public string ConsoleName { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public TechnicalSpecification TechnicalSpecification { get; set; }

        public Brand Brand { get; set; }

        public Company Company { get; set; }
    }
}