
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

        public int TechnicalSpecificationId { get; set; }

        public int BrandId { get; set; }

        public int CompanyId { get; set; }
    }
}